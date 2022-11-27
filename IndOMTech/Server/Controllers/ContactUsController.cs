using IndOMTech.Client.Pages;
using IndOMTech.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace IndOMTech.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactUsController : ControllerBase
{

    private readonly ILogger<ContactUsController> _logger;
    private List<ContactUs> _contactUs = new List<ContactUs>();
    public ContactUsController(ILogger<ContactUsController> logger)
    {
        _logger = logger;
        _contactUs = new List<ContactUs>
            {
                        new ContactUs { ContactUsId = 1, EMail="dk@gmail.com", Name= "DIVS", LastName = "SHAW", Message = "Hi there.."},
                        new ContactUs { ContactUsId = 2, EMail = "jag@gmail.com", Name = "JAG", LastName = "SHAW", Message = "Hi there.." }
                    };
    }

    //[HttpGet]
    //public async Task<List<ContactUs>> Get()
    //{
    //    await Task.Delay(100);
    //    return new List<ContactUs>{
    //        new ContactUs { ContactUsId = 1, EMail="dk@gmail.com", Name= "DIVS", LastName = "SHAW", Message = "Hi there.."},
    //        new ContactUs { ContactUsId = 2, EMail = "jag@gmail.com", Name = "JAG", LastName = "SHAW", Message = "Hi there.." }
    //    };
    //}
    [HttpPost("newcontactus")]
    public async Task<ContactUs> AddContactUs([FromBody] ContactUs contactUs)
    {

        await Task.Delay(1);
        _contactUs.Add(contactUs);
        return await Task.FromResult(_contactUs.FirstOrDefault());
    }

    [HttpPut("updatecontactus/{contacId}")]
    public async Task<ContactUs> UpdateContactUs(int contacId, [FromBody] ContactUs contactUs)
    {

        await Task.Delay(1);
        var c = _contactUs.Where(u => u.ContactUsId == contacId).FirstOrDefault();

        c.Name = contactUs.Name;
        c.LastName = contactUs.LastName;
        c.EMail = contactUs.EMail;

        return await Task.FromResult(c);
    }

    [HttpDelete("deletecontactus/{contacId}")]
    public async Task DeleteContactUs(int contacId)
    {
        var c = _contactUs.Where(x => x.ContactUsId == contacId).FirstOrDefault();
        if (c != null)
        {
            _contactUs.Remove(c);
        }
    }
    [HttpGet("getcontactus/{contId}")]
    public async Task<ContactUs> GetProfile(int contId)
    {
        await Task.Delay(1);
        return _contactUs.FirstOrDefault(u => u.ContactUsId == contId);
    }

    [HttpGet("get1st")]
    public async Task<ContactUs> Get1st()
    {
        await Task.Delay(1);
        return new ContactUs { ContactUsId = 1, EMail = "dk@gmail.com", Name = "DIVS", LastName = "SHAW", Message = "Hi there.." };
        //return _contactUs;

    }

    //[HttpGet]
    //public async Task<ContactUs> Get()
    //{
    //    await Task.Delay(1);
    //    return new ContactUs { ContactUsId = 1, EMail = "dk@gmail.com", Name = "DIVS", LastName = "SHAW", Message = "Hi there.." };
    //}

    [HttpGet]
    public async Task<List<ContactUs>> Get()
    {
        await Task.Delay(1);
        //return new ContactUs { ContactUsId = 1, EMail = "dk@gmail.com", Name = "DIVS", LastName = "SHAW", Message = "Hi there.." };
        return _contactUs;

    }
}
