namespace ScratchWebApi
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.Data.SqlClient;
    public class QuoteEntity
    {
        public int QuoteID { get; set; }
        public string Quote { get; set; }

    }
}
