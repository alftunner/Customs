using System;
using System.Collections.Generic;

namespace ClassProduct
{
    public class ProductDetect
    {
        public delegate void Show(string msg); // Делегат, который будет выводить сообщения
        public static event Show message; // Экземпляр этого делегата
        private string name;
        private string content;
        public static Queue<ProductDetect> warehouse = new Queue<ProductDetect>(); // Очередь в которую будут попадать объекты, содержащие запрещённые вещи (склад)
        private const string stopWord1 = "bomb";
        private const string stopWord2 = "drugs";

        private ProductDetect(string name, string content)
        {
            this.name = name;
            this.content = content;
        }

        public string getName()
        {
            return this.name;
        }
        public string getContent()
        {
            return this.content;
        }

        public static bool Detector(string content) // Возвращает true если груз содержит что-то запрещённое
        {
            bool checkSymbols1 = content.Contains(stopWord1);
            bool checkSymbols2 = content.Contains(stopWord2);

            if (checkSymbols1 || checkSymbols2)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static ProductDetect Create(string name, string content) // возвращает экземляр класса
        {
            if (ProductDetect.Detector(content))
            {
                message("Возможно товар содержит бомбу или наркотики, он будет помещён в специальное хранилище");
                return new ProductDetect(name, content);
            }
            else
            {
                message("Товар прошёл таможню");
                return new ProductDetect(name, "ok");
            }
        }

        public static void toWarehouse(ProductDetect product) // добавляет объект на склад (в конец очереди)
        {
            ProductDetect.warehouse.Enqueue(new ProductDetect(product.name, product.content));
            message("Товар на складе! Не волнуйтесь");
        }
    }
}
