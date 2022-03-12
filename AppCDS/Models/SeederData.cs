using AppCDS.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCDS.Models
{
    public class SeederData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var Context = new DiscosDBContext(serviceProvider.GetRequiredService<DbContextOptions<DiscosDBContext>>());

            if (!Context.Disco.Any())
            {
                Context.Disco.AddRange(
                    new Disco { Autor = "DJ Goldy", NombreDisco = "El Desorden", NumeroCanciones = 14, Anio = 2004 },
                    new Disco { Autor = "Yaga & Mackie", NombreDisco = "Los Mackiavelicos", NumeroCanciones = 14, Anio = 2008 },
                    new Disco { Autor = "Yaga & Mackie", NombreDisco = "La Moda", NumeroCanciones = 15, Anio = 2005 },
                    new Disco { Autor = "Yaga & Mackie", NombreDisco = "Clase Aparte", NumeroCanciones = 22, Anio = 2004 },
                    new Disco { Autor = "Yaga & Mackie", NombreDisco = "Sonando Diferente", NumeroCanciones = 16, Anio = 2002 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "Los Homerunes De Yankee", NumeroCanciones = 23, Anio = 2002 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "El Carte 2: Los Cangris", NumeroCanciones = 16, Anio = 2001 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "El Cartel: The Big Boss", NumeroCanciones = 15, Anio = 2007 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "Mundial", NumeroCanciones = 0, Anio = 2010 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "No Mercy", NumeroCanciones = 14, Anio = 1995 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "El Cangri.Com", NumeroCanciones = 16, Anio = 2002 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "King Daddy Edition", NumeroCanciones = 11, Anio = 2006 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "Prestige", NumeroCanciones = 13, Anio = 2012 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "Talento De Barrio", NumeroCanciones = 12, Anio = 2008 },
                    new Disco { Autor = "Daddy Yankee", NombreDisco = "Barrio Fino", NumeroCanciones = 22, Anio = 2004 },
                    new Disco { Autor = "Johnny Prez", NombreDisco = "Knock Out", NumeroCanciones = 14, Anio = 2007 },
                    new Disco { Autor = "Johnny Prez", NombreDisco = "The Prezident", NumeroCanciones = 16, Anio = 2005 },
                    new Disco { Autor = "Johnny Prez", NombreDisco = "El Dragon", NumeroCanciones = 13, Anio = 2002 },
                    new Disco { Autor = "Yaga & Mackie", NombreDisco = "Los Mackiavelicos HD", NumeroCanciones = 11, Anio = 2012 },
                    new Disco { Autor = "Yaga & Mackie", NombreDisco = "El Catalogo Perdido", NumeroCanciones = 19, Anio = 2020 },
                    new Disco { Autor = "DJ Nelson", NombreDisco = "Flow La Discoteca 1", NumeroCanciones = 22, Anio = 2004 },
                    new Disco { Autor = "Calle 13", NombreDisco = "Calle 13", NumeroCanciones = 13, Anio = 2005 },
                    new Disco { Autor = "Ca", NombreDisco = "Residente o Visitante", NumeroCanciones = 14, Anio = 2007 },
                    new Disco { Autor = "Calle 13", NombreDisco = "Los De Atrás Vienen Conmigo", NumeroCanciones = 14, Anio = 2008 },
                    new Disco { Autor = "Calle 13", NombreDisco = "Entren Los Que Quieran", NumeroCanciones = 15, Anio = 2010 },
                    new Disco { Autor = "Calle 13", NombreDisco = "Multi Viral", NumeroCanciones = 13, Anio = 2014 }
                    );
                Context.SaveChanges();
            }
        }
    }
}
