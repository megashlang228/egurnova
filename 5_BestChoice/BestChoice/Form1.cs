namespace BestChoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        struct Item // �������
        {
            public int weight;  // ���
            public int cost;    // ����
        }
        static int n = 15;      // ���������� ���������
        Item[] a = new Item[n]; // ����� ���������
        int maxWeight;          // ����������� �� ��� �������
        int maxCost;            // ������� ���������� ��������� �������
        int s = 0;              // ������� �������
        int sOpt = 0;           // ����������� �������
        int currentWeight = 0;
        int currentCost = 0;
        int countItem = 0;



        void Opt(int i, int weight, int cost)
        {
            if (weight + a[i].weight <= maxWeight)
            {
                s |= (1 << i); // s=s+[i]; ���������� � �������
                if (i < n-1)
                    Opt(i+1, weight+a[i].weight, cost);
                else
                if (cost > maxCost)
                {
                    maxCost = cost;//��������� ���������
                                   //��������
                    sOpt = s; // ��������� �������
                }
                s &= ~(1<<i); //�������� �� �������
            }
            int tmp = cost - a[i].cost;

            if (tmp > maxCost) // ������� �������� ������� i
                if (i < n - 1)
                    Opt(i + 1, weight, tmp);
                else
                {
                    maxCost = tmp;
                    sOpt = s; // ��������� �������
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int totC = 0;
            for (int i = 0; i < n; i++)
            { //���������� ������� � ���������� ������ ���������
                a[i].weight = (int)dataGridView1[i, 0].Value;
                a[i].cost = (int)dataGridView1[i, 1].Value;
                totC = totC+a[i].cost;
                dataGridView1[i, 2].Value = "";
            }
            maxWeight=Convert.ToInt32(textBox1.Text);
            //���������� ���
            maxCost=0;
            s = 0; sOpt = 0; // �������������
            Opt(0, 0, totC);
            for (int i = 0; i<=n-1; i++) {
                if ((sOpt & (1 << i)) != 0) {
                    dataGridView1[i, 2].Value = "V";
                    countItem++;
                    currentCost += (int)dataGridView1[i, 1].Value;
                    currentWeight += (int)dataGridView1[i, 0].Value;

                }
            }
            this.label_current_cost.Text = currentCost.ToString();
            this.label_current_weight.Text = currentWeight.ToString();
            this.label_item_count.Text = countItem.ToString();
                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
                        
            for (int i = 0; i < a.Length; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[0].Cells[i].Value = rnd.Next(1, int.Parse(textBox1.Text));
                dataGridView1.Rows.Add();
                dataGridView1.Rows[1].Cells[i].Value = rnd.Next(10, 100);
            }
        }

      
    }
}