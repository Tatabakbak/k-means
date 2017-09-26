using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace k_means2
{
	public partial class Form1 : Form
	{
		double[][] rawData;
		double[][] means;
		int numClusters;
        	int checkedNumClusters;
        	int[] clustering;
		bool clustered = false;
		bool meansComputed = false;
        	Brush[] brushes = { Brushes.LimeGreen, Brushes.Blue, Brushes.Orange, Brushes.Red, Brushes.Violet, Brushes.Turquoise };

		public Form1()
		{
			InitializeComponent();
			InitializeTuples();
            		btnClear.Enabled = false;
                 	clusters_group.Enabled = false;
            		checkedNumClusters = 3;        
		}

		// задаем набор случайных даных
		private void InitializeTuples()
		{
			if (rb_group.Checked)
			{
				rawData = new double[20][];
				rawData[0] = new double[] { 422.0, 225.0 };
				rawData[1] = new double[] { 223.0, 160.0 };
				rawData[2] = new double[] { 59.0, 110.0 };
				rawData[3] = new double[] { 66.0, 120.0 };
				rawData[4] = new double[] { 235.0, 150.0 };
				rawData[5] = new double[] { 467.0, 240.0 };
				rawData[6] = new double[] { 468.0, 200.0 };
				rawData[7] = new double[] { 470.0, 250.0 };
				rawData[8] = new double[] { 45.0, 130.0 };
				rawData[9] = new double[] { 466.0, 210.0 };
				rawData[10] = new double[] { 217.0, 190.0 };
				rawData[11] = new double[] { 245.0, 180.0 };
				rawData[12] = new double[] { 234.0, 170.0 };
				rawData[13] = new double[] { 450.0, 214.0 };
				rawData[14] = new double[] { 61.0, 110.0 };
				rawData[15] = new double[] { 50.0, 100.0 };
				rawData[16] = new double[] { 466.0, 225.0 };
				rawData[17] = new double[] { 67.0, 120.0 };
				rawData[18] = new double[] { 498.0, 205.0 };
				rawData[19] = new double[] { 75.0, 130.0 };
			}
			else
			{
				rawData = new double[300][];
				Random random = new Random();
				for (int i = 0; i < rawData.Length; i++)
				{
					rawData[i] = new double[] { random.Next(0, 750), random.Next(0, 350) };
				}
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			Brush b = new SolidBrush(Color.Black);
			if (!clustered)
			{		
				foreach (var p in rawData)
				{
					Point pPosition = new Point((int)p[0], (int)p[1]);
					g.FillEllipse(b, new RectangleF(pPosition, new Size(6, 6)));
				}
			}
			else
			{
				for (int k = 0; k < numClusters; ++k)
				{
					for (int i = 0; i < rawData.Length; ++i)
					{
						int clusterID = clustering[i];
						b = brushes[clusterID];
						if (clusterID != k) continue;
						Point pPosition = new Point((int)rawData[i][0], (int)rawData[i][1]);
						g.FillEllipse(b, new RectangleF(pPosition, new Size(5, 5)));
					}
				}
			}
			if (meansComputed)
			{
				for (int i =0; i < numClusters; i++)
				{
					b = brushes[i];
					Point pPosition = new Point((int)means[i][0], (int)means[i][1]);
					g.FillEllipse(b, new RectangleF(pPosition, new Size(11, 11)));
				}
			}
		}

		// возращает массив кластеров для исходного набора данных
		public int[] Cluster()
		{
            		numClusters = checkedNumClusters;
            		means = new double[numClusters][]; //массив для центроидов
            		for (int k = 0; k < numClusters; ++k)
                	means[k] = new double[rawData[0].Length];
            		bool changed = true; // были изменения в принадлежности к кластеру
			bool success = true; // все точки приписаны к кластерам
			clustering = InitClustering(); // приписываем данным случайные кластеры
			clustered = true;
			while (changed == true && success == true)
			{
				Refresh();
				System.Threading.Thread.Sleep(1500);
				success = UpdateMeans(); // вычисление нового центроида
				changed = UpdateClustering(); // вычисление ближайшего центроида для каждой точки
			}
			return clustering;
		}

		//приписываем каждую точку к случайному кластеру так, чтобы к каждому кластеру была приписана хотя бы одна точка
		private int[] InitClustering()
		{	
			Random random = new Random();
			int[] clustering = new int[rawData.Length];
			for (int i = 0; i < numClusters; ++i) 
				clustering[i] = i;
			for (int i = numClusters; i < clustering.Length; ++i)
				clustering[i] = random.Next(0, numClusters); 
			return clustering; 
		}
		
		// обновление значений центроидов
		private bool UpdateMeans()
		{
			int[] clusterCounts = new int[numClusters]; //количество точек по кластерам
			for (int i = 0; i < rawData.Length; ++i)
			{
				int cluster = clustering[i];
				++clusterCounts[cluster];
			}

			for (int k = 0; k < numClusters; ++k)
				if (clusterCounts[k] == 0)
					return false; // проверка - к каждому кластеру должны быть приписаны точки
			
			for (int k = 0; k < means.Length; ++k) //обнуление центроидов
				for (int j = 0; j < means[k].Length; ++j)
					means[k][j] = 0.0;

			for (int i = 0; i < rawData.Length; ++i)
			{
				int cluster = clustering[i];
				for (int j = 0; j < rawData[i].Length; ++j)
					means[cluster][j] += rawData[i][j]; // записывается сумма координат точек, приписанных кластеру
			}

			for (int k = 0; k < means.Length; ++k)
				for (int j = 0; j < means[k].Length; ++j)
					means[k][j] /= clusterCounts[k]; // находим среднее 
			meansComputed = true;
			return true;
		}

		// обновление распределений по кластерам
		private bool UpdateClustering()
		{
            		bool changed = false;
			int[] newClustering = new int[clustering.Length]; // массив для нового результата
			Array.Copy(clustering, newClustering, clustering.Length);
			double[] distances = new double[numClusters]; // расстояние от точки до центроидов
			for (int i = 0; i < rawData.Length; ++i) // рассчитываем расстоение до цетроидов для всех точек
			{
				for (int k = 0; k < numClusters; ++k)
					distances[k] = Distance(rawData[i], means[k]); 

				int newClusterID = MinIndex(distances); // находим ближайший центроид
				if (newClusterID != newClustering[i])
				{
					changed = true;
					newClustering[i] = newClusterID; 
				}
			}

			if (changed == false) // если изменений в распределении точек по кластерам нет - выход
				return false; 

			int[] clusterCounts = new int[numClusters];
			for (int i = 0; i < rawData.Length; ++i)
			{
				int cluster = newClustering[i];
				++clusterCounts[cluster];
			}

			for (int k = 0; k < numClusters; ++k)
				if (clusterCounts[k] == 0)
					return false; // к каждому кластеру должны быть приписаны точки

			Array.Copy(newClustering, clustering, newClustering.Length);  // копируем полученный массив в исходный
			return true; // если внесены изменеия
		}

		//разница между векторами точки и центроида
		private double Distance(double[] tuple, double[] mean)
		{
			double sumSquaredDiffs = 0.0;
			for (int j = 0; j < tuple.Length; ++j)
				sumSquaredDiffs += Math.Pow((tuple[j] - mean[j]), 2);
			return Math.Sqrt(sumSquaredDiffs);
		}

		private int MinIndex(double[] distances)
		{
			int indexOfMin = 0;
			double smallDist = distances[0];
			for (int k = 0; k < distances.Length; ++k)
			{
				if (distances[k] < smallDist)
				{
					smallDist = distances[k];
					indexOfMin = k;
				}
			}
			return indexOfMin;
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			lbl1.Text = "CLUSTERS:";
			clustered = false;
			meansComputed = false;
			InitializeTuples();
			Refresh();
            		btnGo.Enabled = true;
        	}

		private void btnGo_Click(object sender, EventArgs e)
		{
            		btnClear.Enabled = false;
            		btnGo.Enabled = false;
            		clustering = Cluster();		
			for (int i =0; i< rawData.Length; i++)
			{
				lbl1.Text +="\n"+ i + ". " + clustering[i];
			}
			clustered = true;
			Refresh();
            		btnClear.Enabled = true;
		}

		private void rb_random_CheckedChanged(object sender, EventArgs e)
		{
		    clusters_group.Enabled = true;
		    lbl1.Text = "CLUSTERS:";
		    clustered = false;
		    meansComputed = false;
		    InitializeTuples();
		    Refresh();
		}

		private void rb_group_CheckedChanged(object sender, EventArgs e)
		{
		    rb_3.Checked = true; 
		    clusters_group.Enabled = false;
		}

		private void rb_1_CheckedChanged(object sender, EventArgs e)
		{
		    checkedNumClusters = 1;
		}

		private void rb_2_CheckedChanged(object sender, EventArgs e)
		{
		    checkedNumClusters = 2;
		}

		private void rb_3_CheckedChanged(object sender, EventArgs e)
		{
		    checkedNumClusters = 3;
		}

		private void rb_4_CheckedChanged(object sender, EventArgs e)
		{
		    checkedNumClusters = 4;
		}
    }
}
