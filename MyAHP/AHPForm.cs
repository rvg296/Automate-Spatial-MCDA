//Importing the Libraries
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

// Declaring namespace called MyAHP
namespace MyAHP
{
    public partial class AHPForm : Form
    {
        List<string> nameList = new List<string>();
        double[] rowSum;
        string[] x;
        public AHPForm()
        {
            //Automatic initialization of windows form when created
            InitializeComponent();
            
            //Enabling Autosize to make contents fit
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Exit the add-in when cancel is clicked
        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //About button message
        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AHP Addin for ArcGIS Pro: Developed by Rohit Venkat Gandhi" + '\n' + "Inspired by Oswald Marinoni's extension for ArcMap");
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void AHPForm_Load(object sender, EventArgs e)
        {
            //Make the enter button disabled until map becomes active
            Enter.Enabled = false;
            var mapView = MapView.Active;
            if (mapView == null)
                return;

            //Checking for raster layers in Table of Contents
            var rasterLayers = mapView.Map.Layers.OfType<RasterLayer>();
            mapView.SelectLayers(rasterLayers.ToList());

            int count = rasterLayers.Count();
            RasterLayer rasterLayer;
            
            //Running a lop and checking all visible raster layers
            //Adding them to a raster list
            for (int i = 0; i < count; i++)
            {
                rasterLayer = rasterLayers.ElementAt(i);
                if (rasterLayer.IsVisible)
                {
                    List.Items.Add(rasterLayer);
                    System.Diagnostics.Debug.WriteLine(rasterLayer);

                }


            }
            System.Diagnostics.Debug.WriteLine(List.Items.GetType());


        }

        public void Goal_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public TreeNode[] Find(string key)
        {
            return Goal.Nodes.Find(key, true);
        }
        public void AddToRight_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Please select an item before starting!!");

            //TreeNode node = new TreeNode(List.SelectedItem.ToString());

            //Goal.Nodes.Add(node);
            if (List.SelectedItem == null)
            {
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
                Enter.Enabled = false;
        

        }

        private void AddToLeft_Click(object sender, EventArgs e)
        {

            var str = Goal.SelectedNode;
            List.Items.Add(str.Tag);
            str.Remove();
            int MyNodeCount = Goal.TopNode.GetNodeCount(true);
            
            //Minimum 3 criteria needed for doing this analysis
            if (MyNodeCount >= 3)
            {
                Enter.Enabled = true;

            }
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

            //Selecting no. of simulations
            combo2.Items.Add("2");
            combo2.Items.Add("4");
            combo2.Items.Add("6");
            combo2.Items.Add("8");
            combo2.Items.Add("10");
           

            dataGridView.ColumnCount = Goal.TopNode.GetNodeCount(true);
            dataGridView.RowCount = Goal.TopNode.GetNodeCount(true);

            for (int k = 0; k < Goal.TopNode.GetNodeCount(true); k++)
            {
                this.dataGridView.Columns[k].HeaderText = Goal.TopNode.Nodes[k].Text;
                
                this.dataGridView.Rows[k].HeaderCell.Value = Goal.TopNode.Nodes[k].Text;

                this.dataGridView.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            for (int j = 0; j < Goal.TopNode.GetNodeCount(true); j++)
            {
                this.dataGridView.Rows[j].Cells[j].Value = "1";

            }
            

        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach(DataGridViewColumn dgvc in dataGridView.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
       

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            int r = e.RowIndex;
            int c = e.ColumnIndex;
            if (dataGridView[c,r].Value == null)
            {
                MessageBox.Show("Please enter a value from 1-9 before proceeding");
            }
            else
            {
                double val = Convert.ToDouble(dataGridView[c, r].Value.ToString());
                dataGridView[r, c].Value = ((double)1 / val).ToString("0.00");
            }
            
            
        }

        private void AddMulti_Click(object sender, EventArgs e)
        {

            //TreeNode node = new TreeNode(List.SelectedItems.ToString());

            if (List.SelectedItems == null)
            {
                return;
            }

            foreach (ArcGIS.Desktop.Mapping.RasterLayer Item in List.SelectedItems)
            {

                TreeNode node = Goal.TopNode.Nodes.Add(Item.ToString());
                node.Tag = Item;
                //List.Items.Remove(Item);
            }

            System.Diagnostics.Debug.WriteLine("Rohit hello" + List.SelectedItems.Count);
            int x = List.SelectedItems.Count;
            while (List.SelectedItems.Count != 0)
            {
                List.Items.Remove(List.SelectedItems[0]);

            }
            //Goal.Nodes.Add(node);
            // Goal.TopNode.Nodes.Add(node);

            Goal.ExpandAll();

            int MyNodeCount = Goal.TopNode.GetNodeCount(true);
            if (MyNodeCount >= 3)
            {
                Enter.Enabled = true; ;

            }
            else
                Enter.Enabled = false;
        }

        private void RemoveMulti_Click(object sender, EventArgs e)
        {
            var str = Goal.SelectedNode;
            List.Items.Add(str.Tag);
            str.Remove();
        }




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
                Goal.TopNode.Nodes[i].Text = x[0] + ":" + Math.Round(rowSum[i],3);

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

            textBox1.Text = "CR is " + Convert.ToString(cr);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void ratingMatrix_Click(object sender, EventArgs e)
        {

        }

        private async void Map_Click(object sender, EventArgs e)
        {
            var mapView = MapView.Active;


            //string[,] input_rasters = new string[3, 1] { { @"G:\AdvancedRemoteSensing\LabData\Test\charleston12-8-90tm.img VALUE 0.5" }, { @"G:\AdvancedRemoteSensing\LabData\Test\cola_1-15-91tm.img VALUE 0.5" }, { @"G:\AdvancedRemoteSensing\LabData\Test\cola_10-7-97atlas.img VALUE 0.5" } };
            //node1.Tagb
            //myinputs.Add(RasterLayer(i) + " VALUE " + rowSum[i]);
            //Goal.TopNode.Nodes[i].Text.Split("-->") = x[0] + "-->" + Math.Round(rowSum[i], 3);

            System.Diagnostics.Debug.WriteLine(Goal.TopNode.Nodes[1].Tag.GetType());


            List<string> paths = new List<string>();
            List<string> myinputs = new List<string>();
            TreeNode test = Goal.TopNode;
            //double[] rs = rowSum;

            Task t = QueuedTask.Run(() =>
            {
                for (int k = 0; k < test.Nodes.Count; k++)
                {
                    var rlyrs = MapView.Active.Map.Layers.OfType<RasterLayer>();  //All raster layers
                    //System.Diagnostics.Debug.WriteLine(test.Nodes[k].Tag.ToString());                  
                    for (int m = 0; m < rlyrs.Count(); m++)
                    {

                        RasterLayer rlyr = rlyrs.ElementAt(m); //raster layer at specific position
                        Datastore dataStore = rlyr.GetRaster().GetRasterDataset().GetDatastore(); //getting datasource
                        if (test.Nodes[k].Tag.ToString() == rlyr.Name)
                        {
                            paths.Add(dataStore.GetPath().AbsolutePath);

                            System.Diagnostics.Debug.WriteLine(rlyr.Name);
                            System.Diagnostics.Debug.WriteLine(paths);
                            myinputs.Add(paths.ElementAt(k) + "/" + rlyr.GetRaster().GetRasterDataset().GetName() + " VALUE " + Math.Round(rowSum[k], 2));


                        }
                    }
                }
            });
            t.Wait();



            string output_raster = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster");
            var param_values = Geoprocessing.MakeValueArray(myinputs, output_raster);
            string toolpath = "sa.WeightedSum";
            var env = Geoprocessing.MakeEnvironmentArray(scratchWorkspace: Project.Current.DefaultGeodatabasePath);
            await Geoprocessing.ExecuteToolAsync(toolpath, param_values, env, null, null, GPExecuteToolFlags.None);
            //Geoprocessing.OpenToolDialog("sa.WeightedSum", param_values);        

            //Reclassificaion values assignment
            List<string> remap = new List<string>();
           
            //0 to 0.6 = 1
            //0.6 to 0.8 = 2
            //0.8 to 1 = 3
            
            remap.Add("0 0.6 1");
            remap.Add("0.6 0.8 2");
            remap.Add("0.8 1 3");
            string output_raster2 = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + "reclass0");
            var kufli = Geoprocessing.MakeValueArray(output_raster, "VALUE", remap, output_raster2);
            await Geoprocessing.ExecuteToolAsync("sa.Reclassify", kufli, env, null, null, GPExecuteToolFlags.AddOutputsToMap);
            //Geoprocessing.OpenToolDialog("sa.Reclassify", kufli);



        }




        private void AvailableRasters_Click(object sender, EventArgs e)
        {

        }

        private async void sensitivity_Click(object sender, EventArgs e)
        {
            //Creating a csv file
            //string main = @"D:\";
            //string filepath = main + "myfile.csv";
            //System.Diagnostics.Debug.WriteLine(filepath);

            //if (!File.Exists(filepath))
            //{
            // File.Create(filepath).Close();
            // }

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = true;            
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.InitialDirectory = @"D:\";
            saveFileDialog1.Title = "Save Weights";

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
                Task t = QueuedTask.Run(() =>
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
                t.Wait();
                System.Diagnostics.Debug.WriteLine(i);
                if (i < 0)
                {
                    
                    string output_raster = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + Math.Abs(i) + "down");
                    System.Diagnostics.Debug.WriteLine(output_raster);
                    var param_values = Geoprocessing.MakeValueArray(myinputs, output_raster);
                    string toolpath = "sa.WeightedSum";
                    var env = Geoprocessing.MakeEnvironmentArray(scratchWorkspace: Project.Current.DefaultGeodatabasePath);
                    await Geoprocessing.ExecuteToolAsync(toolpath, param_values, env, null, null, GPExecuteToolFlags.None);

                    List<string> remap = new List<string>();
                    remap.Add("0 0.6 1");
                    remap.Add("0.6 0.8 2");
                    remap.Add("0.8 1 3");
                    string output_raster2 = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + Math.Abs(i) + "downreclass");
                    var kufli = Geoprocessing.MakeValueArray(output_raster, "VALUE", remap, output_raster2);
                    await Geoprocessing.ExecuteToolAsync("sa.Reclassify", kufli, env, null, null, GPExecuteToolFlags.AddOutputsToMap);
                    //Geoprocessing.OpenToolDialog("sa.Reclassify", kufli);
                }
                else
                {

                    string output_raster = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + i + "up");
                    System.Diagnostics.Debug.WriteLine(output_raster);
                    var param_values = Geoprocessing.MakeValueArray(myinputs, output_raster);
                    string toolpath = "sa.WeightedSum";
                    var env = Geoprocessing.MakeEnvironmentArray(scratchWorkspace: Project.Current.DefaultGeodatabasePath);
                    await Geoprocessing.ExecuteToolAsync(toolpath, param_values, env, null, null, GPExecuteToolFlags.None);

                    List<string> remap = new List<string>();
                    remap.Add("0 0.6 1");
                    remap.Add("0.6 0.8 2");
                    remap.Add("0.8 1 3");
                    string output_raster2 = System.IO.Path.Combine(Project.Current.DefaultGeodatabasePath, "SuitedRaster" + Math.Abs(i) + "upreclass");
                    var kufli = Geoprocessing.MakeValueArray(output_raster, "VALUE", remap, output_raster2);
                    await Geoprocessing.ExecuteToolAsync("sa.Reclassify", kufli, env, null, null, GPExecuteToolFlags.AddOutputsToMap);
                    //Geoprocessing.OpenToolDialog("sa.Reclassify", kufli);
                    
                }


                //Geoprocessing.OpenToolDialog("sa.WeightedSum", param_values);



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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void List_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
    
}
