using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount; 

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string mesage)
        {
            count++;
            return mesage.ToLower();
        }

        string ReturnMessage(string mesage)
        {
            count++;
            return mesage;
        }

        //START STRING
        [Fact]
        public void stringBehaveLikeValueType()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        //END STRING

        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref Int32 z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        // C# PASSES AND SETS NEW VALUE BY REFERENCE
       //CAN USE out instead of ref
          [Fact]
        public void CSharpCanPassByReF()
        {
            var book1  =  GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }

        private void GetBookSetName(ref Book book, String name)
        {
            book = new Book(name);

        }

        // C# PASSES VALUE BUT DOES NOT SET NEW VALUE BY BALUE
         [Fact]
        public void CSharpIsPassByValue()
        {
            var book1  =  GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
            
        }

        private void GetBookSetName(Book book, String name)
        {
            book = new Book(name);

        }

        [Fact]
        public void canSetNameFromReference()
        {
            var book1  =  GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
            
        }

        private void SetName(Book book, String name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1  =  GetBook("Book 1");
            var book2  =  GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
            
        }

         [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1  =  GetBook("Book 1");
            var book2  =  book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(String name)
        {
           return new Book(name);
        }
    }
}
