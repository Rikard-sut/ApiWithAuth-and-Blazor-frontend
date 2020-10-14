using ApiWithAuth.Authentication;
using Authmodels;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.AuthProviders
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        public AuthenticationService(HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }
        public async Task<AuthResponseDTO> Login(LoginModel userForAuthentication)
        {
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await _client.PostAsync("https://localhost:5011/api/accounts/login", bodyContent); //todo: Change links.
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDTO>(authContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (!authResult.IsSuccessStatusCode)
                return result;
            await _localStorage.SetItemAsync("authToken", result.Token);
            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(userForAuthentication.Username);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthResponseDTO { IsAuthSuccessful = true };
        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }
    }
}
