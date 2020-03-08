/* This add-in is developed for performing multi criteria decision analysis using the AHP algorithm.
 * Please review how AHP algorithm works and the rating scale used for it before understanding this code base.
 * Since we want our analysis to be smooth, we want to make sure the raster layers are normalized in a uniform scale before performing this analysis.
 * Normalization can be (0 to 1 ) or (1 to 100) -- user friendly.
 * ----------------------------------------------------------
 * Author: Rohit Venkat Gandhi
 * Last Edited: March 2020
 * Requirements : ArcGIS Pro 2.5 , .Net 4.8 Target Framework
 * -----------------------------------------------------------
 */


//Importing namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Core.CIM;
using ArcGIS.Desktop.Core.Geoprocessing;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Core.Data.Raster;
using ArcGIS.Core.Internal.CIM;
using ArcGIS.Desktop.Core;
using ArcGIS.Core.Data;
using System.IO;


//Declaring namespace called MyAHP
namespace MyAHP
{
    public partial class AHPForm : Form
    {
        List<string> nameList = new List<string>();
        double[] rowSum;
        string[] x;
        public AHPForm()
        {          
            InitializeComponent();
            //Setting cancel button to be non-validating
            this.Cancel.CausesValidation = false;
 
        }

        //AHP Form Load
        private void AHPForm_Load(object sender, EventArgs e)
        {
            //Make all buttons initially disabled
            Enter.Enabled = false;
            Cal.Enabled = false;
            Map.Enabled = false;


            //If there is no mapview dont do anything
            var mapView = MapView.Active;
            if (mapView == null)
                return;

            //Checking for raster layers in Table of Contents
            var rasterLayers = mapView.Map.Layers.OfType<RasterLayer>();
            mapView.SelectLayers(rasterLayers.ToList());

            int count = rasterLayers.Count();
            RasterLayer rasterLayer;
            
            //Running a loop and checking all visible raster layers
            //Adding them to a raster list
            for (int i = 0; i < count; i++)
            {
                rasterLayer = rasterLayers.ElementAt(i);
                if (rasterLayer.IsVisible)
                {
                    List.Items.Add(rasterLayer);
                }


            }
            System.Diagnostics.Debug.WriteLine(List.Items.GetType());


            //For Handling Cell Validation and End Edit
            this.dataGridView.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView_CellValidating);
            this.dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellEndEdit);
        }



        //public TreeNode[] Find(string key)
        //{
        //    return Goal.Nodes.Find(key, true);
        //}


        public void AddToRight_Click(object sender, EventArgs e)
        {           
            //TreeNode node = new TreeNode(List.SelectedItem.ToString());
            //Goal.Nodes.Add(node);
            if (List.SelectedItem == null)
            {
                MessageBox.Show("Please Select a criteria to proceed");
                return;
            }
            TreeNode node1 = Goal.TopNode.Nodes.Add(List.SelectedItem.ToString());
            node1.Tag = List.SelectedItem;
            nameList.Add(List.SelectedItem.ToString());


            Goal.ExpandAll();
            List.Items.Remove(List.SelectedItem);
            
            int MyNodeCount = Goal.TopNode.GetNodeCount(true);
            if (MyNodeCount >= 3)
            {
                Enter.Enabled = true;
            }
                
            else
            {
                Enter.Enabled = false;
            }
                
        }

        private void AddMulti_Click(object sender, EventArgs e)
        {
            if (List.SelectedItems == null)
            {
                MessageBox.Show("Select Criteria to proceed");
                return;
            }

            foreach (RasterLayer Item in List.SelectedItems)
            {

                TreeNode node = Goal.TopNode.Nodes.Add(Item.ToString());
                node.Tag = Item;
            }

            System.Diagnostics.Debug.WriteLine("Rohit hello" + List.SelectedItems.Count);

            //Remove the items from listbox once they are added to treeview
            while (List.SelectedItems.Count != 0)
            {
                List.Items.Remove(List.SelectedItems[0]);

            }
           //Expand the tree by default
            Goal.ExpandAll();

            //Enabled the enter button only if 3 criteria are taken
            int MyNodeCount = Goal.TopNode.GetNodeCount(true);
            if (MyNodeCount >= 3)
            {
                Enter.Enabled = true;

            }
            else
                Enter.Enabled = false;
        }


        private void AddToLeft_Click(object sender, EventArgs e)
        {
            
            if (Goal.TopNode.Nodes.Count == 0)
            {
                MessageBox.Show("Add to criteria first before removing");
            }
            
            /*Since we have only one parent node, we can just check if any child  is selected in it or not and restrict parent removal */
            else if((Goal.SelectedNode != null) && (Goal.SelectedNode.Text!="Goal"))
            {
                List.Items.Add(Goal.SelectedNode.Tag);
                Goal.SelectedNode.Remove();
                Goal.SelectedNode = null;
            }
            
        
            else
            {
                MessageBox.Show("You have not selected a criteria that can be removed");
            }


            //Do not allow user to go further if the tree does not have miniumn 3 criteria
            int MyNodeCount = Goal.TopNode.GetNodeCount(true);
            if (MyNodeCount >= 3)
                Enter.Enabled = true;
            else
                Enter.Enabled = false;

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Enter_Click(object sender, EventArgs e)
        {
            
            //Selecting Criterion for Sensitivity Analysis
            for (int c = 0; c < Goal.TopNode.GetNodeCount(true); c++)
            {
                combo1.Items.Add(Goal.TopNode.Nodes[c].Text.ToString());
                System.Diagnostics.Debug.WriteLine(Goal.TopNode.Nodes[c].Text);
            }

            //Adding no of simulations
            //You can add as many as you need
            combo2.Items.Add("2");
            combo2.Items.Add("4");
            combo2.Items.Add("6");
            combo2.Items.Add("8");
            combo2.Items.Add("10");


            //Enabling sensitivity analysis only when options are selected
            if (combo1.SelectedIndex != -1 || combo2.SelectedIndex != -1)
            {
                sensitivity.Enabled = true;
            }


            dataGridView.ColumnCount = Goal.TopNode.GetNodeCount(true);
            dataGridView.RowCount = Goal.TopNode.GetNodeCount(true);

            for (int k = 0; k < Goal.TopNode.GetNodeCount(true); k++)
            {

                //Populate the row and column names with selected criteria
                this.dataGridView.Columns[k].HeaderText = Goal.TopNode.Nodes[k].Text;
                
                this.dataGridView.Rows[k].HeaderCell.Value = Goal.TopNode.Nodes[k].Text;

            }


            for (int j = 0; j < Goal.TopNode.GetNodeCount(true); j++)
            {
                //Fill the diagonal elements with 1 and make sure they are read-only
                this.dataGridView.Rows[j].Cells[j].Value = "1";
                this.dataGridView.Rows[j].Cells[j].ReadOnly = true;

            }
            

        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Dont allow user to sort columns since AHP matrix gets messed up
            foreach(DataGridViewColumn dgvc in dataGridView.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        //Allow the user to close form if needed even when cell validation fails
        //Taken from Stack-Overflow
        protected override void WndProc(ref Message m)
        
        {
            switch (((m.WParam.ToInt64() & 0xffff) & 0xfff0))
            {
                case 0xf060:
                    this.dataGridView.CausesValidation = false;
                    break;
            }

            base.WndProc(ref m);
        }

        //-----------Cell Value Validations start here----------------------
        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;

            dataGridView.Rows[r].ErrorText = "";
            int newInteger;

            //Dont validate if its a new row or if value is already filled (for inverse values)
            if ((dataGridView.Rows[r].IsNewRow) || (dataGridView[c, r].Value != null))

            {
                return;
            }

            // Validate if the cell is not empty
            else if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                dataGridView.Rows[r].ErrorText =
                    "Cell Value Should not be empty";
                e.Cancel = true;
            }

            //Validate if the cell value is in range 1 and 9
            else if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 1 || newInteger > 9)
            {
                dataGridView.Rows[r].ErrorText = "Cell Value should be in between 1 to 9 (inclusive)";
                e.Cancel = true;
            }

        }



        
        //Event occurs after a cell value is entered
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            int c = e.ColumnIndex;

            dataGridView.Rows[r].ErrorText = String.Empty;
            double val = Convert.ToDouble(dataGridView[c, r].Value.ToString());
            dataGridView[r, c].Value = ((double)1 / val).ToString("0.00");


            //The following code enables CalculateWeights to appear only if everything is correct
            var allValid = true;
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    var v = cell.Value;
                    if(v==null || v==DBNull.Value|| string.IsNullOrEmpty(v.ToString()))
                    {
                        //We found invalid cell & breaking
                        allValid = false;
                        break;
                    }
                }
                // A cell in this row was invalid - no need to check next row
                if (!allValid) break;
            }
            //If all cells were valid, allvalid is still true
            Cal.Enabled = allValid;

        }

        //Calculation of Weights start here
        public void Cal_Click_1(object sender, EventArgs e)
        {
          
            double sum = 0;
            double[] columnSum = new double[dataGridView.RowCount];
            double[,] gridResult = new double[dataGridView.RowCount, dataGridView.ColumnCount];
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                sum = 0;
                for (int j = 0; j < dataGridView.RowCount; j++)
                {
                    sum += Convert.ToDouble(dataGridView[i, j].Value);

                }
                Console.WriteLine(sum);
                columnSum[i] = sum;
            }

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {

                for (int j = 0; j < dataGridView.RowCount; j++)
                {
                    gridResult[j, i] = Convert.ToDouble(dataGridView[i, j].Value) / columnSum[i];

                }
                Console.WriteLine();
            }

            for (int i = 0; i < dataGridView.RowCount; i++)
            {

                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    Console.Write(gridResult[i, j] + " ");
                }
                Console.WriteLine();


            }

            rowSum = new double[dataGridView.RowCount];

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    rowSum[i] += gridResult[i, j];
                }
                rowSum[i] = rowSum[i] / (dataGridView.ColumnCount);
                Console.WriteLine("Row" + i + " " + rowSum[i]);
                String[] s = new String[] { ":" };
                x = Goal.TopNode.Nodes[i].Text.Split(s, 2, StringSplitOptions.None);
                Goal.TopNode.Nodes[i].Text = x[0] + "-->" + Math.Round(rowSum[i],3);

            }

            double[] mm = new double[dataGridView.RowCount];

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    mm[i] += (Convert.ToDouble(dataGridView[j, i].Value) * rowSum[j]);


                }

                Console.WriteLine("Row" + i + " " + mm[i] / rowSum[i]);

            }


            double[] mmf = new double[dataGridView.RowCount];
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                mmf[i] = (double)(mm[i] / rowSum[i]);
            }



            double avg = mmf.Sum() / dataGridView.RowCount;
            double ci = (avg - dataGridView.RowCount) / (dataGridView.RowCount - 1);
            Console.WriteLine("This is the final" + ci);

            
            
            //Refer to Saaty's Scale
            double ri = 0.00;

            if (dataGridView.RowCount == 1)
            {
                ri = 0.00;
            }
            else if (dataGridView.RowCount == 2)

            {
                ri = 0.00;
            }
            else if (dataGridView.RowCount == 3)

            {
                ri = 0.58;
            }
            else if (dataGridView.RowCount == 4)

            {
                ri = 0.9;
            }
            else if (dataGridView.RowCount == 5)

            {
                ri = 1.12;
            }
            else if (dataGridView.RowCount == 6)

            {
                ri = 1.24;
            }
            else if (dataGridView.RowCount == 7)

            {
                ri = 1.32;

            }
            else if (dataGridView.RowCount == 8)

            {
                ri = 1.41;

            }
            else if (dataGridView.RowCount == 9)

            {
                ri = 1.46;

            }
            else if (dataGridView.RowCount == 10)

            {
                ri = 1.49;

            }

            double cr = Math.Round((ci / ri),2);

            if (cr>0.1){
                MessageBox.Show("Consistency Ratio = "+ Convert.ToString(cr)+" Please revise your ratings in order to obtain CR less than or equal to 0.1");
            }

            else
            {
                textBox1.Text = "CR is " + Convert.ToString(cr) + '\n' + ". Your corresponding criteria weights are displayed on the left (Tree)";
                Map.Enabled = true;
            }
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //Click to create suitability map
        private async void Map_Click(object sender, EventArgs e)
        {
            var mapView = MapView.Active;
            List<string> paths = new List<string>();
            List<string> myinputs = new List<string>();
            TreeNode test = Goal.TopNode;

           
            //using await instead of .wait() for asynchronous execution (Wait for the results)
            await QueuedTask.Run(() =>
            {
                for (int k = 0; k < test.Nodes.Count; k++)
                {
                    var rlyrs = MapView.Active.Map.Layers.OfType<RasterLayer>();  //All raster layers                        
                    for (int m = 0; m < rlyrs.Count(); m++)
                    {

                        RasterLayer rlyr = rlyrs.ElementAt(m); //raster layer at specific position
                        Datastore dataStore = rlyr.GetRaster().GetRasterDataset().GetDatastore(); //getting datasource

                        if (test.Nodes[k].Tag.ToString() == rlyr.Name)
                        {
                            paths.Add(dataStore.GetPath().AbsolutePath);

                            myinputs.Add(paths.ElementAt(k) + "/" + rlyr.GetRaster().GetRasterDataset().GetName() + " VALUE " + Math.Round(rowSum[k], 2));
                        }
                    }
                }

            });
            //t.Wait();


            //For Showing Progress Window (Optional)
            var progDlgWS = new ProgressDialog("Weighted Sum Progress", "Cancel", 100, true);
            
            progDlgWS.Show();

            var progSrc = new CancelableProgressorSource(progDlgWS);

            string weightedSumRaster = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster");
            var param_values = Geoprocessing.MakeValueArray(myinputs, weightedSumRaster);
            
            //use toolBoxNameAlias.toolName.Alias
            string toolpath = "sa.WeightedSum";
            
            var env = Geoprocessing.MakeEnvironmentArray(scratchWorkspace: Project.Current.DefaultGeodatabasePath);

            //Uncomment below line if you want GP tool to open in Pro
            //Geoprocessing.OpenToolDialog(toolpath, param_values);

            progressLabel.Text = "Performing Weighted Sum, please wait...";

            //Not adding weighted sum result to map since its intermediate result
            await Geoprocessing.ExecuteToolAsync(toolpath, param_values, env, new CancelableProgressorSource(progDlgWS).Progressor,  GPExecuteToolFlags.AddOutputsToMap);

            progressLabel.Text = "Weighted Sum processing complete. Reclassification started";

            //Hide the progress once done.
            progDlgWS.Hide();

            
            //----Use this if you want to see GP result messages---//
            //---The flow doesnt progress forward unless you close this box-----//
            //Geoprocessing.ShowMessageBox(wsresult.Messages, "GP Messages",
            //wsresult.IsFailed ? GPMessageBoxStyle.Error : GPMessageBoxStyle.Default);                 


            //Creating a list string to store reclass values
            List<string> remap = new List<string>();

            //Classifying into 3 classes, values can be modified as per user needs.
            
            remap.Add("0 0.6 1"); //Least Suitable
            remap.Add("0.6 0.8 2"); //Moderately Suitable
            remap.Add("0.8 1 3"); //Highly Suitable

            string output_raster2 = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + "reclass0");
            var reclassedRaster = Geoprocessing.MakeValueArray(weightedSumRaster, "VALUE", remap, output_raster2);
            await Geoprocessing.ExecuteToolAsync("sa.Reclassify", reclassedRaster, env, null, null, GPExecuteToolFlags.AddOutputsToMap);

            progressLabel.Text = "Reclassification Completed. Check in TOC";
            //Geoprocessing.OpenToolDialog("sa.Reclassify", reclassedRaster);

            


        }



        private async void sensitivity_Click(object sender, EventArgs e)
        {
            if ((combo1.SelectedIndex == -1)|| (combo2.SelectedIndex == -1)){
                MessageBox.Show("Cannot Perform SA unless criteria and simulations are selected");
                return;
            }
                     
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv file (*.csv)|*.csv|txt file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;            
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Title = "Save your Weights";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    
                    myStream.Close();
                }
            }
            else if(saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Save your csv file");
            }
            string fp = saveFileDialog1.FileName;

            // Defining new array rowSum1 with length as rowSum
            double[] rowSum1 = new double[rowSum.Length];

            for (int i = -Convert.ToInt16(combo2.SelectedItem)/2; i<= Convert.ToInt16(combo2.SelectedItem)/2; i++)
            {
                //Copy contents of rowSum to rowSum1 starting from 0
                rowSum.CopyTo(rowSum1,0);
                if (i == 0)
                {
                    continue;
                }

                for (int j = 0; j < combo1.Items.Count; j++)
                {                   
                    //Positive Increment 
                    if (i > 0)
                    {
                        rowSum1[combo1.SelectedIndex] = rowSum1[combo1.SelectedIndex] * (1 + 0.01 * i);
                        if (j != combo1.SelectedIndex)
                        {
                            System.Diagnostics.Debug.WriteLine(i);
                            rowSum1[j] = rowSum1[j] * (1 - 0.01 * i);
                        }
                    }
                    //Negative increment
                    else
                    {
                        rowSum1[combo1.SelectedIndex] = rowSum1[combo1.SelectedIndex] * (1 + 0.01 * i);
                        if (j != combo1.SelectedIndex)
                        {
                            System.Diagnostics.Debug.WriteLine(i);
                            rowSum1[j] = rowSum1[j] * (1 - 0.01 * i);
                        }
                    }
                    //Skip iteration when i=0
                    
                }
                // Writing to a csv file
                string delimiter = ",";
                int length = rowSum1.Length;
                //using (TextWriter writer = File.CreateText(filepath))

                using (TextWriter writer = File.AppendText(fp))
                //StringBuilder csv = new StringBuilder();                           
                {
                    if (i==-Convert.ToInt16(combo2.SelectedItem)/ 2)
                    {
                        writer.Write(string.Join(delimiter, "% Change", "\t"));
                        for (int a = 0; a < combo1.Items.Count; a++)
                        {
                            
                            writer.Write(string.Join(delimiter,combo1.Items[a], "\t"));
                        }
                    }
                    
                   
                    writer.Write("\n");
                    writer.Write(string.Join(delimiter,i,"\t"));
                   
                    
                    for(int index = 0; index < length; index++)
                    {
                        
                        writer.Write(string.Join(delimiter,Math.Round(rowSum1[index], 3),"\t"));                       

                    }
                }

                List<string> paths = new List<string>();
                List<string> myinputs = new List<string>();
                TreeNode test = Goal.TopNode;
                
                //Geoprocessing starts here
               await QueuedTask.Run(() =>
               // Task t = QueuedTask.Run(() =>
                {
                    for (int k = 0; k < test.Nodes.Count; k++)
                    {
                        var rlyrs = MapView.Active.Map.Layers.OfType<RasterLayer>();  //All raster layers in Map View
                       //System.Diagnostics.Debug.WriteLine(test.Nodes[k].Tag.ToString());                  
                        for (int m = 0; m < rlyrs.Count(); m++)
                        {

                            RasterLayer rlyr = rlyrs.ElementAt(m); //raster layer at specific position
                            Datastore dataStore = rlyr.GetRaster().GetRasterDataset().GetDatastore(); //getting datasource
                            if (test.Nodes[k].Tag.ToString() == rlyr.Name)
                            {
                                paths.Add(dataStore.GetPath().AbsolutePath);//getting path

                                System.Diagnostics.Debug.WriteLine(rlyr.Name);
                                System.Diagnostics.Debug.WriteLine(paths);

                                // adding paths to input array, value and weights
                                myinputs.Add(paths.ElementAt(k) + "/" + rlyr.GetRaster().GetRasterDataset().GetName() + " VALUE " + Math.Round(rowSum1[k], 3));
                                System.Diagnostics.Debug.WriteLine(rowSum1);
                            }
                        }
                    }
                });
                //t.Wait();
                
                System.Diagnostics.Debug.WriteLine(i);
                if (i < 0)
                {
                    
                    string output_raster = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + Math.Abs(i) + "down");
                    System.Diagnostics.Debug.WriteLine(output_raster);
                    var param_values = Geoprocessing.MakeValueArray(myinputs, output_raster);
                    string toolpath = "sa.WeightedSum";
                    var env = Geoprocessing.MakeEnvironmentArray(scratchWorkspace: Project.Current.DefaultGeodatabasePath);
                    await Geoprocessing.ExecuteToolAsync(toolpath, param_values, env, null, null, GPExecuteToolFlags.None);

                    progressLabel.Text = "Reclassification Started for " + Math.Abs(i).ToString() + " % decrease";

                    List<string> remap = new List<string>();
                    remap.Add("0 0.6 1");
                    remap.Add("0.6 0.8 2");
                    remap.Add("0.8 1 3");
                    string output_raster2 = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + Math.Abs(i) + "downreclass");
                    var kufli = Geoprocessing.MakeValueArray(output_raster, "VALUE", remap, output_raster2);
                    //Geoprocessing.OpenToolDialog("sa.Reclassify", kufli);
                    await Geoprocessing.ExecuteToolAsync("sa.Reclassify", kufli, env, null, null, GPExecuteToolFlags.AddOutputsToMap);

                    progressLabel.Text = "Reclassification Finished for " + Math.Abs(i).ToString() + " % decrease. Check in TOC";

                }
                else
                {

                    string output_raster = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + i + "up");
                    System.Diagnostics.Debug.WriteLine(output_raster);
                    var param_values = Geoprocessing.MakeValueArray(myinputs, output_raster);
                    string toolpath = "sa.WeightedSum";
                    var env = Geoprocessing.MakeEnvironmentArray(scratchWorkspace: Project.Current.DefaultGeodatabasePath);
                    await Geoprocessing.ExecuteToolAsync(toolpath, param_values, env, null, null, GPExecuteToolFlags.None);

                    progressLabel.Text = "Reclassification Started for " + Math.Abs(i).ToString() + " % increase";

                    List<string> remap = new List<string>();
                    remap.Add("0 0.6 1");
                    remap.Add("0.6 0.8 2");
                    remap.Add("0.8 1 3");
                    string output_raster2 = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + Math.Abs(i) + "upreclass");
                    var kufli = Geoprocessing.MakeValueArray(output_raster, "VALUE", remap, output_raster2);

                    //Geoprocessing.OpenToolDialog("sa.Reclassify", kufli);

                    await Geoprocessing.ExecuteToolAsync("sa.Reclassify", kufli, env, null, null, GPExecuteToolFlags.AddOutputsToMap);

                    progressLabel.Text = "Reclassification Finished for " + Math.Abs(i).ToString() + " % increase. Check in TOC";
                }

                foreach (var Item in rowSum1)
                {
                    System.Diagnostics.Debug.WriteLine(Item.ToString());
                }


                // Clear the array so that new values will be populated based on original
                Array.Clear(rowSum1, 0, rowSum1.Length);

                //Clear inputs
                myinputs.Clear();
                               
            }                     

        }

        //Exit the add-in when close is clicked
        private void Cancel_Click(object sender, EventArgs e)
        {
            dataGridView.CancelEdit();
            Application.Exit();
        }

        //About button message
        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AHP Addin for ArcGIS Pro: Developed by Rohit Venkat Gandhi" + '\n' + "Inspired by Oswald Marinoni's extension for ArcMap");
        }

        private void clearMatrix_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
        }
    }
    
}
