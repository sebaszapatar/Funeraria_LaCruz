using Funeraria_LaCruz.API.Data;
using Funeraria_LaCruz.API.Helpers;
using Funeraria_LaCruz.Shared.Entities;
using Funeraria_LaCruz.Shared.Enums;
using Funeraria_LaCruz.API.Services;
using Funeraria_LaCruz.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Funeraria_LaCruz.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        private readonly IApiService _apiService;

        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IApiService apiService, IUserHelper userHelper)
        {
            _context = context;
            _apiService = apiService;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            //await CheckCountriesAsync();
           
            await CheckCategoriesAsync();
            await CheckEmployeesAsync();
            await CheckServicesAsync();
            await CheckPlansAsync();
            await CheckdeceasedAsync();

            await CheckRolesAsync();
            await CheckUserAsync("1", "Domingo", "Festivo", "szr@yopmail.com", "300445555", "cosa", UserType.Admin);

        }


        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }





        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category
                {
                    Name = "Entierros",
                    FunerariaCategories = new List<FunerariaCategory>()
            {
                new FunerariaCategory()
                {
                    Name = "Ataúdes",
                    Products = new List<Product>() {
                        new Product() { Name = "Ataúd Modelo Clásico",
                                             Descripcion = "Ataúd de madera sólida con diseño elegante y acabado brillante",
                                             Color = "Caoba",
                                             Material = "Madera",
                                             Stock = "15",
                                             Precio = "$1.500.000"},
                        new Product() { Name = "Ataúd Modelo Lujo",
                                             Descripcion = "Ataúd de alta gama con detalles ornamentales y acabado dorado",
                                             Color = "Dorado",
                                             Material = "Madera y metal",
                                             Stock = "5",
                                             Precio = " $5.000.000"},
                        new Product() { Name = "Ataúd Modelo Moderno",
                                             Descripcion = "Ataúd de metal con líneas modernas y acabado plateado",
                                             Color = "Plata",
                                             Material = "Metal",
                                             Stock = "12",
                                             Precio = "$2.000.000" },
                        new Product() { Name = "Ataúd Modelo Sencillo",
                                             Descripcion = "Ataúd básico de madera con acabado liso y sobrio",
                                             Color = "Natural",
                                             Material = "Madera",
                                             Stock = "18",
                                             Precio = "$800.000"},
                        new Product() { Name = "Ataúd Infantil",
                                             Descripcion = "Ataúd de tamaño reducido especialmente diseñado para niños",
                                             Color = "Blanco",
                                             Material = "Madera",
                                             Stock = "7",
                                             Precio = "$1.200.000" },
                    }
                },
                
            }
                });
                _context.Categories.Add(new Category
                {
                    Name = "Cremaciones",
                    FunerariaCategories = new List<FunerariaCategory>()
            {
                new FunerariaCategory()
                {
                    Name = "Urnas",
                    Products = new List<Product>() {
                        new Product() { Name = "Urna con Relieve Floral",
                                             Descripcion = "Urna de cerámica decorada con relieves florales en relieve",
                                             Color = "Blanco",
                                             Material = "Cerámica",
                                             Stock = "8",
                                             Precio = "$500.000 " },
                        new Product() { Name = "Urna Ecológica Biodegradable",
                                             Descripcion = "Urna fabricada con materiales biodegradables y diseño natural",
                                             Color = "Verde bosque",
                                             Material = "Bioplástico",
                                             Stock = "20",
                                             Precio = "$300.000"  },
                        new Product() {Name = "Urna de Mármol0",
                                             Descripcion = "Urna de mármol con elegante diseño y acabado pulido",
                                             Color = "Negro",
                                             Material = "Mármol",
                                             Stock = "3",
                                             Precio = "$1.200.000"  },
                        new Product() { Name = "Urna de Acero Inoxidable",
                                             Descripcion = "Urna de acero inoxidable resistente y de aspecto moderno",
                                             Color = "Plateado",
                                             Material = "Acero inoxidable",
                                             Stock = "10",
                                             Precio = "$600.000"  },
                        new Product() { Name = "Urna de Vidrio Grabada",
                                             Descripcion = "Urna de vidrio transparente con grabados delicados y elegantes",
                                             Color = "Transparente",
                                             Material = "Vidrio",
                                             Stock = "6",
                                             Precio = "$900.000" }
                    }
                },
                
            }
                });
            }

            await _context.SaveChangesAsync();
        }


        private async Task CheckEmployeesAsync()
        {
            if (!_context.Employees.Any())

            {

                _context.Employees.Add(new Employee
                {
                    Cedula = "876543210",
                    FullName = " Laura Rodríguez Gómez",
                    Dir = "Calle 456, Bogotá",
                    Cargo = "Coordinadora de Servicios Funerarios",
                    Tel = "7890123456",
                    Email = "laura.rodriguez@example.com"
                });

                _context.Employees.Add(new Employee
                {
                    Cedula = "765432109",
                    FullName = " Carlos Ramírez Pérez",
                    Dir = "Carrera 789, Medellín",
                    Cargo = "Embalsamador",
                    Tel = "6789012345",
                    Email = "carlos.ramirez@example.com "
                });

                _context.Employees.Add(new Employee
                {
                    Cedula = "654321098",
                    FullName = "Andrea López Vargas",
                    Dir = "Calle 987, Bogotá",
                    Cargo = "Coordinadora de Velatorios",
                    Tel = "5678901234",
                    Email = "andrea.lopez@example.com"
                });

                _context.Employees.Add(new Employee
                {
                    Cedula = "543210987",
                    FullName = "Ricardo González Castro",
                    Dir = "Carrera 321, Medellín",
                    Cargo = "Conductor de Vehículo Fúnebre",
                    Tel = "4567890123",
                    Email = "ricardo.gonzalez@example.com"
                });

                _context.Employees.Add(new Employee
                {
                    Cedula = "432109876",
                    FullName = "Diana Martínez Gómez",
                    Dir = "Calle 654, Bogotá",
                    Cargo = "Recepcionista",
                    Tel = "3456789012",
                    Email = "diana.martinez@example.com"
                });

                _context.Employees.Add(new Employee
                {
                    Cedula = "321098765",
                    FullName = "Oscar Vargas Ramírez",
                    Dir = "Carrera 123, Medellín",
                    Cargo = "Técnico Funerario",
                    Tel = "2345678901",
                    Email = "oscar.vargas@example.com"
                });

                _context.Employees.Add(new Employee
                {
                    Cedula = "210987654",
                    FullName = "Alejandra Castro López",
                    Dir = "Calle 789, Bogotá",
                    Cargo = "Atención al Cliente",
                    Tel = "1234567890",
                    Email = "alejandra.castro@example.com "
                });
            }

            await _context.SaveChangesAsync();

        }

        private async Task CheckServicesAsync()
        {

            if (!_context.Services.Any())

            {

                _context.Services.Add(new Service
                {
                    Name = "Carroza fúnebre",
                    Precio = "$150.000",
                });

                _context.Services.Add(new Service
                {
                    Name = "Servicio de Embalsamamiento",
                    Precio = "$300.000",
                });

                _context.Services.Add(new Service
                {
                    Name = "Traslado Nacional e Internacional",
                    Precio = "$500.000 (tarifa base) + costos adicionales según la distancia y ubicación",
                });

                _context.Services.Add(new Service
                {
                    Name = "Velatorio en Capilla",
                    Precio = "$200.000 por día",
                });

                _context.Services.Add(new Service
                {
                    Name = "Preparación y Presentación del Difuntoo",
                    Precio = "$250.000",
                });

                _context.Services.Add(new Service
                {
                    Name = "Gestión de Trámites Legales y Documentación",
                    Precio = "$150.000 (no incluye costos legales adicionales) ",
                });


            }

            await _context.SaveChangesAsync();

        }

        private async Task CheckPlansAsync()
        {

            if (!_context.Plans.Any())

            {

                _context.Plans.Add(new Plan
                {
                    Name = "Plan Básico",
                    Descripcion = "Incluye servicios funerarios básicos, como el ataúd estándar, el traslado dentro de la ciudad y la gestión de documentos legales.",
                    Precio = "$500.000",
                });

                _context.Plans.Add(new Plan
                {
                    Name = "Plan Familiar",
                    Descripcion = "Diseñado para cubrir las necesidades de una familia, incluye servicios funerarios completos para un número específico de miembros, como ataúdes, velatorio y ceremonia.",
                    Precio = "$1.200.000",
                });

                _context.Plans.Add(new Plan
                {
                    Name = "Plan Cremación",
                    Descripcion = "Orientado a aquellos que desean la cremación como opción final, incluye servicios de preparación del difunto, urna, ceremonia de despedida y asesoramiento en temas relacionados con la cremación.",
                    Precio = "$800.000",
                });

                _context.Plans.Add(new Plan
                {
                    Name = "Plan VIP",
                    Descripcion = "Un plan de lujo que ofrece servicios personalizados y exclusivos, como ataúd premium, ceremonia especial, transporte de lujo, asistencia personalizada para la familia y opciones adicionales según las preferencias individuales.",
                    Precio = "$3.000.000",
                });

                _context.Plans.Add(new Plan
                {
                    Name = "Plan Solidario",
                    Descripcion = "Un plan diseñado para brindar servicios funerarios a personas con recursos limitados, incluye ataúd económico, velatorio sencillo y gestión de trámites legales básicos.",
                    Precio = " $300.000",
                });


            }


            await _context.SaveChangesAsync();

        }

        private async Task CheckdeceasedAsync()
        {

            if (!_context.deceased.Any())

            {

                _context.deceased.Add(new Deceased
                {
                    Cedula = "1123456789",
                    FullName = "Juan Carlos Gómez",
                    Sexo = "Masculino",
                    Nacimiento = "10 de abril de 1985",
                    Defuncion = "5 de marzo de 2022",
                    CausaMuerte = "Accidente automovilístico",
                    LugarFallecimiento = "Bogotá",
                    EstadoCivil = "Soltero"
                });

                _context.deceased.Add(new Deceased
                {
                    Cedula = "9876543210",
                    FullName = "María Fernández López",
                    Sexo = "Femenino",
                    Nacimiento = "22 de julio de 1990",
                    Defuncion = "15 de enero de 2023",
                    CausaMuerte = "Enfermedad cardíaca",
                    LugarFallecimiento = "Medellín",
                    EstadoCivil = "Casada"
                });

                _context.deceased.Add(new Deceased
                {
                    Cedula = "5678901234",
                    FullName = "Andrés Pérez Rodríguez",
                    Sexo = "Masculino",
                    Nacimiento = "5 de marzo de 1978",
                    Defuncion = "20 de abril de 2023",
                    CausaMuerte = "COVID-19",
                    LugarFallecimiento = "Cali",
                    EstadoCivil = "Divorciado"
                });

                _context.deceased.Add(new Deceased
                {
                    Cedula = "4321098765",
                    FullName = "Carolina Ramírez Vargas",
                    Sexo = "Femenino",
                    Nacimiento = "2 de noviembre de 2002",
                    Defuncion = "7 de febrero de 2023",
                    CausaMuerte = "Se ahogo con su propia escupa",
                    LugarFallecimiento = "Barranquilla",
                    EstadoCivil = "Soltera"
                });

                _context.deceased.Add(new Deceased
                {
                    Cedula = "8765432109",
                    FullName = "Alejandro González Castro",
                    Sexo = "Masculino",
                    Nacimiento = "18 de septiembre de 1995",
                    Defuncion = "3 de diciembre de 2022",
                    CausaMuerte = "Complicaciones durante una cirugía",
                    LugarFallecimiento = "Cartagena",
                    EstadoCivil = "Casado"
                });
            }

            await _context.SaveChangesAsync();

        }




        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");
                if (responseCountries.IsSuccess)
                {
                    List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result!;
                    foreach (CountryResponse countryResponse in countries)
                    {
                        Country country = await _context.Countries!.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name!, States = new List<State>() };
                            Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.IsSuccess)
                            {
                                List<StateResponse> states = (List<StateResponse>)responseStates.Result!;
                                foreach (StateResponse stateResponse in states!)
                                {
                                    State state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                        Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.IsSuccess)
                                        {
                                            List<CityResponse> cities = (List<CityResponse>)responseCities.Result!;
                                            foreach (CityResponse cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                City city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name! });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.StatesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
        }

    }
    }
