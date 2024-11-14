using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dime.Utilities.Tests
{
    public class ClusteredDictionaryTests
    {
        [Fact]
        [Trait("Category", "ClusteredDictionary")]
        public void ClusteredDictionary_AllKeysArePopulated()
        {
            ClusteredDictionary<Crud> crudBucket = new ClusteredDictionary<Crud>();

            List<Customer> newCustomers =
            [
                new Customer { Id =  1},
                new Customer { Id =  2}
            ];

            List<Customer> moreNewCustomers =
            [
                new Customer { Id =  10000},
                new Customer { Id =  10001}
            ];

            List<Customer> updatedCustomers =
            [
                new Customer { Id =  3},
                new Customer { Id =  4}
            ];

            List<Customer> deletedCustomers =
            [
                new Customer { Id =  5},
                new Customer { Id =  6}
            ];

            List<Order> newOrders =
            [
                new Order { Id =  100},
                new Order { Id =  200}
            ];

            List<Order> updatedOrders =
            [
                new Order { Id =  300},
                new Order { Id =  400}
            ];

            List<Order> deletedOrders =
            [
                new Order { Id =  500},
                new Order { Id =  600}
            ];

            crudBucket.Add(Crud.Create, newCustomers);
            crudBucket.Add(Crud.Create, moreNewCustomers);
            crudBucket.Add(Crud.Update, updatedCustomers);
            crudBucket.Add(Crud.Delete, deletedCustomers);

            crudBucket.Add(Crud.Create, newOrders);
            crudBucket.Add(Crud.Update, updatedOrders);
            crudBucket.Add(Crud.Delete, deletedOrders);

            Assert.True(crudBucket.Get<Customer>(Crud.Create).Count() == 4);
            Assert.True(crudBucket.Get<Customer>(Crud.Create).ElementAt(0).Id == 1);
            Assert.True(crudBucket.Get<Customer>(Crud.Create).ElementAt(1).Id == 2);

            Assert.True(crudBucket.Get<Customer>(Crud.Update).Count() == 2);
            Assert.True(crudBucket.Get<Customer>(Crud.Update).ElementAt(0).Id == 3);
            Assert.True(crudBucket.Get<Customer>(Crud.Update).ElementAt(1).Id == 4);

            Assert.True(crudBucket.Get<Customer>(Crud.Delete).Count() == 2);
            Assert.True(crudBucket.Get<Customer>(Crud.Delete).ElementAt(0).Id == 5);
            Assert.True(crudBucket.Get<Customer>(Crud.Delete).ElementAt(1).Id == 6);

            Assert.True(crudBucket.Get<Order>(Crud.Create).Count() == 2);
            Assert.True(crudBucket.Get<Order>(Crud.Create).ElementAt(0).Id == 100);
            Assert.True(crudBucket.Get<Order>(Crud.Create).ElementAt(1).Id == 200);

            Assert.True(crudBucket.Get<Order>(Crud.Update).Count() == 2);
            Assert.True(crudBucket.Get<Order>(Crud.Update).ElementAt(0).Id == 300);
            Assert.True(crudBucket.Get<Order>(Crud.Update).ElementAt(1).Id == 400);

            Assert.True(crudBucket.Get<Order>(Crud.Delete).Count() == 2);
            Assert.True(crudBucket.Get<Order>(Crud.Delete).ElementAt(0).Id == 500);
            Assert.True(crudBucket.Get<Order>(Crud.Delete).ElementAt(1).Id == 600);
        }

        [Fact]
        [Trait("Category", "ClusteredDictionary")]
        public void ClusteredCrudDictionary_NotAllKeysArePopulated()
        {
            ClusteredDictionary<Crud> crudBucket = new ClusteredDictionary<Crud>();

            List<Customer> newCustomers =
            [
                new Customer { Id =  1},
                new Customer { Id =  2}
            ];

            List<Customer> updatedCustomers =
            [
                new Customer { Id =  3},
                new Customer { Id =  4}
            ];

            List<Customer> deletedCustomers =
            [
                new Customer { Id =  5},
                new Customer { Id =  6}
            ];

            List<Order> newOrders =
            [
                new Order { Id =  100},
                new Order { Id =  200}
            ];

            List<Order> updatedOrders =
            [
                new Order { Id =  300},
                new Order { Id =  400}
            ];

            List<Order> deletedOrders =
            [
                new Order { Id =  500},
                new Order { Id =  600}
            ];

            crudBucket.Add(Crud.Update, updatedCustomers);
            crudBucket.Add(Crud.Delete, deletedCustomers);

            crudBucket.Add(Crud.Create, newOrders);
            crudBucket.Add(Crud.Update, updatedOrders);
            crudBucket.Add(Crud.Delete, deletedOrders);

            Assert.True(!crudBucket.Get<Customer>(Crud.Create).Any());

            Assert.True(crudBucket.Get<Customer>(Crud.Update).Count() == 2);
            Assert.True(crudBucket.Get<Customer>(Crud.Update).ElementAt(0).Id == 3);
            Assert.True(crudBucket.Get<Customer>(Crud.Update).ElementAt(1).Id == 4);

            Assert.True(crudBucket.Get<Customer>(Crud.Delete).Count() == 2);
            Assert.True(crudBucket.Get<Customer>(Crud.Delete).ElementAt(0).Id == 5);
            Assert.True(crudBucket.Get<Customer>(Crud.Delete).ElementAt(1).Id == 6);

            Assert.True(crudBucket.Get<Order>(Crud.Create).Count() == 2);
            Assert.True(crudBucket.Get<Order>(Crud.Create).ElementAt(0).Id == 100);
            Assert.True(crudBucket.Get<Order>(Crud.Create).ElementAt(1).Id == 200);

            Assert.True(crudBucket.Get<Order>(Crud.Update).Count() == 2);
            Assert.True(crudBucket.Get<Order>(Crud.Update).ElementAt(0).Id == 300);
            Assert.True(crudBucket.Get<Order>(Crud.Update).ElementAt(1).Id == 400);

            Assert.True(crudBucket.Get<Order>(Crud.Delete).Count() == 2);
            Assert.True(crudBucket.Get<Order>(Crud.Delete).ElementAt(0).Id == 500);
            Assert.True(crudBucket.Get<Order>(Crud.Delete).ElementAt(1).Id == 600);
        }
    }
}