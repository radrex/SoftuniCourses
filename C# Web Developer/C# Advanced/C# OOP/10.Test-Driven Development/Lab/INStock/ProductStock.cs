namespace INStock
{
    using INStock.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductStock : IProductStock, IEnumerable<IProduct>
    {
        //--------- Fields ----------
        private List<IProduct> productStock;

        //------ Constructors -------
        public ProductStock()
        {
            this.productStock = new List<IProduct>();
        }

        //------- Properties --------
        public IProduct this[int index]
        {
            get
            {
                if (index >= 0 && index < this.productStock.Count)
                {
                    return this.productStock[index] as IProduct;
                }

                throw new IndexOutOfRangeException("Index was out of range!");
            }

            set
            {
                if (index < 0 && index >= this.productStock.Count)
                {
                    throw new IndexOutOfRangeException("Index was out of range!");
                }

                this.productStock.Insert(index, value);
            }
        }

        public int Count => this.productStock.Count;

        //-------- Methods ----------
        public void Add(IProduct product)
        {
            foreach (IProduct prod in this.productStock)
            {
                if (prod.CompareTo(product) == 0)
                {
                    throw new ArgumentException("Product already existing!");
                }
            }

            this.productStock.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (IProduct prod in this.productStock)
            {
                if (prod.CompareTo(product) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (index >= 0 && index < this.productStock.Count)
            {
                return this.productStock[index];
            }

            throw new IndexOutOfRangeException("Index was out of range!");
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return productStock.Where(p => decimal.ToDouble(p.Price) == price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return productStock.Where(p => p.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return productStock.Where(p => decimal.ToDouble(p.Price) >= lo && decimal.ToDouble(p.Price) <= hi)
                               .OrderByDescending(p => p.Price).ToList();
        }

        public IProduct FindByLabel(string label)
        {
            if (!this.productStock.Any(p => p.Label == label))
            {
                throw new ArgumentException("No such product in stock!");
            }

            return this.productStock.First(p => p.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return this.productStock.OrderByDescending(p => p.Price)
                                    .ToList()
                                    .FirstOrDefault();
        }

        public bool Remove(IProduct product)
        {
            return this.productStock.Remove(product);
        }

        //------------------------------------------
        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < this.productStock.Count; i++)
            {
                yield return this.productStock[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
