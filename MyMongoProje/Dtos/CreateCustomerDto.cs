﻿namespace MyMongoProje.Dtos
{
    public class CreateCustomerDto
    {
       
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public decimal CustomerBalance { get; set; }
    }
}