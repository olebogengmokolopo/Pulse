﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Monitor.Models;

namespace Stethoscope
{
    class PulseReporter : IReporter
    {
        private readonly string _pulseServerAddress;
        private static readonly HttpClient HttpClient = new HttpClient();

        public PulseReporter(string pulseServerAddress)
        {
            HttpClient.BaseAddress = new Uri(pulseServerAddress);
        }

        public async void Report<T>(T reading) where T : ISensorReading
        {
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpClient.DefaultRequestHeaders.Authorization = GetAuthenticationHeader();

            var readingTarget = reading.GetSensorTarget();
            var response = await HttpClient.PostAsJsonAsync(readingTarget, reading);
            response.EnsureSuccessStatusCode();
        }

        private AuthenticationHeaderValue GetAuthenticationHeader()
        {
            var authenticationData = "username:password";

            var authenticationBytes = Encoding.ASCII.GetBytes(authenticationData);
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authenticationBytes));
        }
    }
}