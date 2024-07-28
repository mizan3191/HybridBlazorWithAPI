using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net;
using WebDomain;

namespace HybridyApps.MyServices
{
        public class MyHybridServices : IMyHybridClassServices
        {
            private readonly HttpClient _httpClient;
            private readonly NavigationManager _navigationManager;

            public MyHybridServices(HttpClient httpClient, NavigationManager navigationManager)
            {
                _httpClient = httpClient;
                _navigationManager = navigationManager;
            }

            public async Task CreateMyClass(MyClass product)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync("Values", product);
                    if (response.IsSuccessStatusCode)
                    {
                        _navigationManager.NavigateTo("weather");
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                    }
                }
                catch (Exception)
                {
                    // Log exception
                    throw;
                }
            }

            public async Task UpdateMyClass(MyClass product)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync($"Values/{product.Id}", product);
                    if (response.IsSuccessStatusCode)
                    {
                        _navigationManager.NavigateTo("weather");
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("Category not found.");
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                    }
                }
                catch (Exception)
                {
                    // Log exception
                    throw;
                }
            }

            public async Task DeleteMyClass(int id)
            {
                try
                {
                    var response = await _httpClient.DeleteAsync($"Values/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        _navigationManager.NavigateTo("weather");
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new Exception("My Class not found.");
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                    }
                }
                catch (Exception)
                {
                    // Log exception
                    throw;
                }
            }

            public async Task<MyClass> GetMyClass(int id)
            {
                try
                {
                    var response = await _httpClient.GetAsync($"Values/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            return default(MyClass);
                        }

                        return await response.Content.ReadFromJsonAsync<MyClass>();
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                    }
                }
                catch (Exception)
                {
                    //Log exception
                    throw;
                }
            }

            public async Task<IEnumerable<MyClass>> GetMyClassess()
            {
                try
                {
                    var response = await _httpClient.GetAsync("Values");
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                        {
                            return Enumerable.Empty<MyClass>();
                        }

                        return await response.Content.ReadFromJsonAsync<IEnumerable<MyClass>>();
                    }
                    else
                    {
                        var message = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception details for debugging
                    Console.WriteLine($"Error in GetItems(): {ex}");
                    throw;
                }
            }
        }
    }