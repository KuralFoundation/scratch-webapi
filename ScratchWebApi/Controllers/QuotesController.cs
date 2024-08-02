using Microsoft.AspNetCore.Mvc;
using ScratchWebApi; // Ensure the namespace matches where your QuotesRepository is defined
using System;
using System.Collections.Generic;

namespace ScratchWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuotesRepository _quotesRepository;

        public QuotesController(QuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public ActionResult<QuoteEntity> Get()
        {
            var quotes = _quotesRepository.GetAllQuotes();
            if (quotes.Count == 0)
            {
                return NotFound("No quotes found.");
            }

            var random = new Random();
            var randomQuote = quotes[random.Next(quotes.Count)];

            return Ok(randomQuote);
        }
    }
}
