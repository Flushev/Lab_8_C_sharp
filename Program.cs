using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Laba_6
{
   
    class shoes
    {
        
        private string name;
        private string type;
        private string art;
        private double price;

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
            Console.WriteLine("Хуй");
            Console.WriteLine("Введите название бренда");
            name = Console.ReadLine();
            Console.WriteLine("Введите вид обуви");
            type = Console.ReadLine();
            Console.WriteLine("Введите артикул");
            art = Console.ReadLine();
            Console.WriteLine("Введите стоимость");
            price = Int32.Parse(Console.ReadLine());
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
        const double stavka = 0.24;
        private int kol;
        private double profit;
        private int sale_count;
        private shoes [] para = new shoes [100];
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

        public void nalog (out double k)
        {
            k = this.Profit * stavka;
        }

        public void Nalog (ref double k)
        {
            k = this.Profit * stavka;
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
            double tax;

            Console.WriteLine("Работа со статическими объектами");
            shoes pr1 = new shoes();
            pr1.read();
            shop sh1 = new shop(1, 0, 0, pr1);
            sh1.display();
            Console.WriteLine("\nПосле продажи: \n");
            sh1.sale();
            sh1.nalog(out tax);
            Console.WriteLine("Налог через Out: {0}", tax);
            tax = 0;
            sh1.Nalog(ref tax);
            Console.WriteLine("Налог через Ref: {0}", tax);
            sum = pr1.add(sum);
            Console.WriteLine("Общая стоимость товаров: {0}\n", sum);
            sum = pr1.return_sum(sum);
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
            }
            shop sh2 = new shop(k, 0, 0, pr2);
            sh2.display();
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
