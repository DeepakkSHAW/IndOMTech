using IndOMTech.Client.Pages;
using IndOMTech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
 
namespace IndOMTech.Client.ViewModels
{
    public class ContactUsViewModel : IContactUsViewModel
    {
        private HttpClient _httpClient;

        public string Message { get; set; } = "..";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public string? Query { get; set; }

        public ContactUsViewModel()
        {

        }
        public ContactUsViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private void LoadCurrentContactUs(ContactUs contactUs)
        {
            this.Email = contactUs.EMail;
            this.Name = contactUs.Name;
            this.LastName = contactUs.LastName;
            this.Query = contactUs.Message;
            this.Message = "message loaded.";
        }
        //private void LoadCurrentContactUs(List<ContactUs> contactUs)
        //{
        //    foreach (var item in contactUs)
        //    {
        //        this.Email = contactUs.EMail;
        //        this.Name = contactUs.Name;
        //        this.LastName = contactUs.LastName;
        //        this.Query = contactUs.Message;
        //        this.Message = "message loaded.";
        //    }
        //}

        public async Task GetContact()
        {
            //List<ContactUs> contactUs = await _httpClient.GetFromJsonAsync<List<ContactUs>>("contactus/get1st");
            //Console.WriteLine(contactUs.Count());

            ContactUs contactUs = await _httpClient.GetFromJsonAsync<ContactUs>("contactus/get1st");
            Console.WriteLine(contactUs.ContactUsId);
            LoadCurrentContactUs(contactUs);
        }

        public async Task Get1stContact()
        {
            //List<ContactUs> contactUs = await _httpClient.GetFromJsonAsync<List<ContactUs>>("contactus/get1st");
            //Console.WriteLine(contactUs.Count());

            ContactUs contactUs = await _httpClient.GetFromJsonAsync<ContactUs>("contactus/get1st");
            Console.WriteLine(contactUs.ContactUsId);
            LoadCurrentContactUs(contactUs);
        }

        public static implicit operator ContactUsViewModel(ContactUs contactus)
        {
            return new ContactUsViewModel
            {
                Query = contactus.Message,
                Name = contactus.Name,
                LastName = contactus.LastName,
                Email = contactus.EMail
                //Mobile = contactus.ContactNumber
            };
        }

        public static implicit operator ContactUs(ContactUsViewModel contactUsViewModel)
        {

            return new ContactUs
            {
                //ContactNumber = contactUsViewModel.Mobile,
                Message = contactUsViewModel.Query,
                Name = contactUsViewModel.Name,
                LastName = contactUsViewModel.LastName,
                EMail = contactUsViewModel.Email
            };
        }
    }
}
