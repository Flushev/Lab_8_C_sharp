using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Laba_7
{
   
    class shoes
    {
        
        private string name;
        private string type;
        private string art;
        private double price;
        static Exception e;

       public shoes ()
        {
            this.name = "Имя";
            this.type = "Вид";
            this.art = "Артикул";
            this.price = 0;
        }
        public shoes (string name, string type, string art, double price)
        {
            this.name = name;
            this.type = type;
            this.art = art;
            this.price = price;
        }

        public shoes (double price)
        {
            this.name = "Имя";
            this.type = "Вид";
            this.art = "Артикул";
            this.price = price;
        }
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }
        public string Type
        {
            get { return type; }
            set { this.type = value; }
        }
    
        public string Art
        {
            get { return art; }
            set { this.art= value; }
        }

        public double Price
        {
            get { return price; }
            set { this.price = value; }
        }

        public void read ()
        {
            int f = 0;
            double temp;
            Console.WriteLine("Введите название бренда");
            name = Console.ReadLine();
            Console.WriteLine("Введите вид обуви");
            type = Console.ReadLine();
            Console.WriteLine("Введите артикул");
            art = Console.ReadLine();
            // Обработка исключений
            while (f == 0)
            {
                Console.WriteLine("Введите стоимость");
                temp = Int32.Parse(Console.ReadLine());
                try
                {
                    if (temp > 0)
                    {
                        f = 1;
                        price = temp;
                    }
                    else
                    {
                        throw e = new Exception ("Ошибка ввода! Стоимость не может быть отрицательной!");
                        f = 0;
                    }
                }
                catch (Exception e)
                {
                    string s;
                    s = e.Message;
                    Console.WriteLine(s);
                    Console.ReadKey();

                }
            }
        }
        public void display()
        {
            Console.WriteLine("\nБренд: {0}\nВид: {1}\nАртикул: {2}\nСтоимость: {3}\n", name, type, art, price);
        }
        public double add (double sum)
        {
            return sum += this.price;
        }


        public double return_sum (double sum)
        {
            return sum -= this.price;
        }
    }

    class shop
    {
        private int kol;
        private double profit;
        private int sale_count;
        private shoes [] para = new shoes [100];
        private static int stavka;
        private int box;
        private int k_box;
        private shoes [,] para_1 = new shoes [10, 10];
        private shoes[] para_2 = new shoes[10];
        public shop ()
        {
            this.kol = 0;
            this.profit = 0;
            this.sale_count = 0;
        }
        public shop (int kol, double profit, int sale_count, shoes para)
        {
            this.kol = kol;
            this.profit = profit;
            this.sale_count = sale_count;
            this.para[0] = para;
        }
        public shop (int kol, double profit, int sale_count, shoes [] para)
        {
            this.kol = kol;
            this.profit = profit;
            this.sale_count = sale_count;
            for (int i = 0; i < kol; i++)
                this.para[i] = para[i];
        }
        // Конструктор для склада обуви
        public shop(int box, int k_box, shoes[,] para)
        {
            this.kol = box * k_box;
            this.box = box;
            this.k_box = k_box;
            for (int i = 0; i < box; i++) // Количество коробок
                for (int j = 0; j < k_box; j++) // Количество пар в коробке
                    this.para_1[i, j] = para[i, j];

        }
        // Конструктор для одной коробки
        public shop (int k_box, shoes[] para)
        {
            this.kol = k_box;
            this.k_box = k_box;
            for (int i = 0; i < k_box; i++) // Количество пар в коробке
                this.para_2[i] = para[i];
        }

        public double cost_sklad ()
        {
            double cost = 0;
            for (int i = 0; i < box; i++)
                for (int j = 0; j < k_box; j++)
                    cost += para_1[i,j].Price;
            return cost;
        }

        public double cost_box ()
        {
            double cost = 0;
            for (int i = 0; i < k_box; i++)
                cost += para_2[i].Price;
            return cost;

        }

       public void display_sklad()
        {
            Console.WriteLine("Количество коробок на складе {0}", box);
            Console.WriteLine ("Количество пар в коробке {0}", k_box);
            Console.WriteLine("Общее количесво пар на складе {0}", kol);
            Console.WriteLine("Общая стоимость товаров на складе {0}", cost_sklad());
            for (int i = 0; i < box; i++)
            {
                for (int j = 0; j < k_box; j++)
                    para_1[i,j].display();
                Console.WriteLine("\n");
            }

        }
        public void display_box()
        {
            Console.WriteLine("Количество пар в коробке {0}", k_box);
            Console.WriteLine("Общая стоимость товаров на складе {0}", cost_box());
            for (int i = 0; i < k_box; i++)
                para_2[i].display();

        }
        public int Kol
        {
            get { return kol; }
            set { this.kol = value; }
        }
        public double Profit
        {
            get { return profit; }
            set { this.profit = value; }
        }
        public int Sale_count
        {
            get { return sale_count; }
            set { this.sale_count = value; }
        }
        
        public void read ()
        {
            Console.WriteLine("Введите количество товаров\n");
            kol = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите выручку\n");
            profit = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество продаж\n");
            sale_count = Int32.Parse(Console.ReadLine());
        }
        public void display()
        {
            Console.WriteLine("\nКоличество товаров: {0}\nВыручка: {1}\nКоличество продаж: {2}\n ", kol, profit, sale_count);
            for (int i = 0; i < kol; i ++)
            {
                Console.WriteLine("{0}:\n", i+1);
                Console.WriteLine("Бренд: {0}\n Вид: {1}\nАртикул: {2}\nСтоимость: {3}\n", this.para[i].Name, this.para[i].Type, this.para[i].Art, this.para[i].Price);
            }
        }
        public void sale()
        {
                profit += this.para[kol-1].Price;
                sale_count++;
                kol -= 1;
            Console.WriteLine("\nПродажа прошла успешно!\n");
        }
        public void back()
        {
                profit -= this.para[kol].Price;
                sale_count--;
                kol += 1;
            Console.WriteLine ("\nВозврат прошел успешно\n");
        }

        public static void nalog (ref int k)
        {
            stavka = 0;
            stavka += 300;
            k = stavka;
        }


        public static shop operator++ (shop tmp)
        {
            ++tmp.sale_count;
            return tmp;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            int tax = 0;

            //Двумерный массив объектов
            shoes[,] p = new shoes[10, 10];
            int box = 0;
            int k_box = 0;
            Console.WriteLine("Введите количество коробок на складе");
            box = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество пар в коробке");
            k_box = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < box; i++)
                for (int j = 0; j < k_box; j++)
                {
                    p[i, j] = new shoes();
                    p[i,j].read();
                }
            shop sklad = new shop (box, k_box, p);
            sklad.display_sklad();

            // Одномерный массив объектов
            Console.WriteLine("Введите количество пар в коробке");
            k_box = Convert.ToInt32(Console.ReadLine());
            shoes[] p1 = new shoes [10];
            for (int i = 0; i < k_box; i ++)
            {
                p1[i] = new shoes();
                p1[i].read();
            }
            shop boxx = new shop(k_box, p1);
            boxx.display_box();
            //Массив через конструтор с одним параметром
            shoes[] s = new shoes [2];
            Console.WriteLine("Инициализация массива через коутркутор с 1 параметром");
            for (int i = 0; i < 2; i++)
            {
                s[i] = new shoes(i);
                s[i].display();
            }
            Console.WriteLine("Работа со статическими объектами");
            
            // Конструктор без параметров
            shoes pr1 = new shoes();
            pr1.read();

            // Конструктор со всеми параметрами
            shop sh1 = new shop(1, 0, 0, pr1);
            sh1.display();

            // Статический метод
            shop.nalog(ref tax);
            Console.WriteLine("Налог на обувь: {0}\n", tax);

            Console.WriteLine("\nПосле продажи: \n");
            sh1.sale();

            Console.WriteLine("Общая стоимость товаров: {0}\n", sum);
            sum = pr1.add(sum);
            sh1.display();
            Console.WriteLine("Общая стоимость товаров: {0}\n", sum);
            Console.WriteLine("\nПосле возврата: \n");
            sh1.back();
            sum = pr1.add(sum);
            sh1.display();
            Console.WriteLine("Перегрузки:\n");
            shop sh10 = new shop(1, 0, 3, pr1);
            sh10 = ++sh1;
            Console.WriteLine("Перефикс {0}:", sh10.Sale_count);
            sh10.Sale_count = 3;
            sh1.Sale_count = 0;
            sh10 = sh1++;
            Console.WriteLine("Постфикс {0}:", sh10.Sale_count);
            Console.WriteLine("Общая стоимость товаров: {0}\n", sum);
            tax = 0;
            Console.WriteLine("\nРабота с динамическими объектами\n");
            Console.WriteLine ("Введите количество позиций:\n");
            sum = 0;
            int k = Int32.Parse(Console.ReadLine());
            shoes[] pr2 = new shoes[k];
            for (int i = 0; i < k; i++)
            {
                pr2[i] = new shoes();
                pr2[i].read();
                sum = pr2[i].add(sum);
                // Статический метод
                shop.nalog(ref tax);
            }
            shop sh2 = new shop(k, 0, 0, pr2);
            sh2.display();
            Console.WriteLine("Налог на обувь: {0}\n", tax);
            Console.WriteLine("Общая стоимость товаров: {0}\n", sum);
            Console.WriteLine("\nПосле продажи: \n");
            sh2.sale();
            sum = pr2[sh2.Kol].return_sum(sum);
            sh2.display();
            Console.WriteLine("Общая стоимость товаров: {0}\n", sum);
            Console.WriteLine("\nПосле возврата: \n");
            sh2.back();
            sum = pr2[sh2.Kol - 1].add(sum);
            sh2.display();
        }
    }
}
