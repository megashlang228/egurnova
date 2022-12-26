namespace BestChoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        struct Item // предмет
        {
            public int weight;  // вес
            public int cost;    // цена
        }
        static int n = 15;      // количество предметов
        Item[] a = new Item[n]; // набор предметов
        int maxWeight;          // ограничение на вес выборки
        int maxCost;            // текущая наибольшая стоимость выборки
        int s = 0;              // текущая выборка
        int sOpt = 0;           // оптимальная выборка
        int currentWeight = 0;
        int currentCost = 0;
        int countItem = 0;



        void Opt(int i, int weight, int cost)
        {
            if (weight + a[i].weight <= maxWeight)
            {
                s |= (1 << i); // s=s+[i]; добавление в выборку
                if (i < n-1)
                    Opt(i+1, weight+a[i].weight, cost);
                else
                if (cost > maxCost)
                {
                    maxCost = cost;//запомнить локальный
                                   //максимум
                    sOpt = s; // запомнить выборку
                }
                s &= ~(1<<i); //удаление из выборки
            }
            int tmp = cost - a[i].cost;

            if (tmp > maxCost) // попытка добавить предмет i
                if (i < n - 1)
                    Opt(i + 1, weight, tmp);
                else
                {
                    maxCost = tmp;
                    sOpt = s; // запомнить выборку
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int totC = 0;
            for (int i = 0; i < n; i++)
            { //обновление массива и вычисление полной стоимости
                a[i].weight = (int)dataGridView1[i, 0].Value;
                a[i].cost = (int)dataGridView1[i, 1].Value;
                totC = totC+a[i].cost;
                dataGridView1[i, 2].Value = "";
            }
            maxWeight=Convert.ToInt32(textBox1.Text);
            //предельный вес
            maxCost=0;
            s = 0; sOpt = 0; // инициализация
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