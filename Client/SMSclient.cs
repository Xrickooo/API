using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KursachBot.Constants;
using KursachBot.Model;
using Microsoft.AspNetCore.Mvc;
using Kursach.SendSMS;


public class SMSclient
{
    private HttpClient _client;
    public static string _address;
    public static string _apiKey;
    public SMSclient()
    {
        _address = Constants.address2;
        _apiKey = Constants.apiKey2;
        _client = new HttpClient();
        _client.BaseAddress = new Uri(_address);
    }

    public async Task SendSMS(SMSmodel model)
    {
        var stringPayload = JsonConvert.SerializeObject(model);

        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        //var header = "ZS-Z5-i-0OVWsNO";
        _client.DefaultRequestHeaders.Add("Authorization", "Bearer ZS-Z5-i-0OVWsNO");
        var response = await _client.PostAsync($"sms/send", httpContent);
        var content = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<Model[]>(content);

    }
}
