using System;
using System.Collections.Generic;
using HigoApi.Models;
using HigoApi.Models.DTO;
using HigoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HigoApi.Controllers
{
    [Route("api/mock/operaciones")]
    [ApiController]
    public class OperacionesMockController : ControllerBase
    {
        private readonly IOperacionService operacionService;

        public OperacionesMockController(IOperacionService operacionService)
        {
            this.operacionService = operacionService;
        }

        // GET
        [HttpGet]
        public IActionResult GetOperaciones([FromQuery(Name = "usuario")] int idUsuario)
        {
            return Ok(GetDummyData(idUsuario, true));
        }

        private static OperacionesClasificadasDTO GetDummyData(int idUsuario, Boolean esPrestador = false)
        {
            OperacionesClasificadasDTO operaciones = new OperacionesClasificadasDTO();

            var adquirientePorEstado = new OperacionesPorEstadoDTO();

            adquirientePorEstado.Pendientes = new List<OperacionDTO>
            {
                new OperacionDTO
                {
                    IdOperacion = 1,
                    IdAdquiriente = 4,
                    IdVehiculo = 1,
                    CodEstado = EstadoOperacion.PENDIENTE,
                    Estado = "Pendiente de aprobacion",
                    Prestador = "Mario Santos",
                    Adquirente = "Jose Fehler",
                    Vehiculo = "Fiat Palio",
                    MontoAcordado = 500.00m,
                    MontoEfectivo = 550.00m,
                    FechaHoraDesde = DateTime.UtcNow,
                    FechaHoraHasta = DateTime.UtcNow
                }
            };
            adquirientePorEstado.EnCurso = new List<OperacionDTO>
            {
                new OperacionDTO
                {
                    IdOperacion = 2,
                    IdAdquiriente = 4,
                    IdVehiculo = 2,
                    CodEstado = EstadoOperacion.EJECUCION,
                    Estado = "En curso",
                    Prestador = "Mario Santos",
                    Adquirente = "Jose Fehler",
                    Vehiculo = "Fiat Palio",
                    MontoAcordado = 500.00m,
                    MontoEfectivo = 550.00m,
                    FechaHoraDesde = DateTime.UtcNow,
                    FechaHoraHasta = DateTime.UtcNow
                }
            };
            
            adquirientePorEstado.Finalizadas = new List<OperacionDTO>
            {
                new OperacionDTO
                {
                    IdOperacion = 2,
                    IdAdquiriente = 4,
                    IdVehiculo = 2,
                    CodEstado = EstadoOperacion.FINALIZADO,
                    Estado = "Finalizado",
                    Prestador = "Mario Santos",
                    Adquirente = "Jose Fehler",
                    Vehiculo = "Fiat Palio",
                    MontoAcordado = 500.00m,
                    MontoEfectivo = 550.00m,
                    FechaHoraDesde = DateTime.UtcNow,
                    FechaHoraHasta = DateTime.UtcNow
                },
                new OperacionDTO
                {
                    IdOperacion = 3,
                    IdAdquiriente = 4,
                    IdVehiculo = 3,
                    CodEstado = EstadoOperacion.CANCELADO,
                    Estado = "Cancelado por Adquiriente",
                    Prestador = "Mario Santos",
                    Adquirente = "Jose Fehler",
                    Vehiculo = "Fiat Palio",
                    MontoAcordado = 500.00m,
                    MontoEfectivo = 550.00m,
                    FechaHoraDesde = DateTime.UtcNow,
                    FechaHoraHasta = DateTime.UtcNow
                }
            };

            operaciones.Adquirente = adquirientePorEstado;

            if (esPrestador)
            {
                var prestadorPorEstado = new OperacionesPorEstadoDTO();

                prestadorPorEstado.Pendientes = new List<OperacionDTO>
                {
                    new OperacionDTO
                    {
                        IdOperacion = 4,
                        IdAdquiriente = 1,
                        IdVehiculo = 4,
                        CodEstado = EstadoOperacion.PENDIENTE,
                        Estado = "Pendiente de aprobacion",
                        Prestador = "Mario Santos",
                        Adquirente = "Jose Fehler",
                        Vehiculo = "Fiat Palio",
                        MontoAcordado = 500.00m,
                        MontoEfectivo = 550.00m,
                        FechaHoraDesde = DateTime.UtcNow,
                        FechaHoraHasta = DateTime.UtcNow
                    },
                    new OperacionDTO
                    {
                        IdOperacion = 5,
                        IdAdquiriente = 2,
                        IdVehiculo = 4,
                        CodEstado = EstadoOperacion.PENDIENTE,
                        Estado = "Pendiente de aprobacion",
                        Prestador = "Mario Santos",
                        Adquirente = "Jose Fehler",
                        Vehiculo = "Fiat Palio",
                        MontoAcordado = 500.00m,
                        MontoEfectivo = 550.00m,
                        FechaHoraDesde = DateTime.UtcNow,
                        FechaHoraHasta = DateTime.UtcNow
                    }
                };
                prestadorPorEstado.EnCurso = new List<OperacionDTO>
                {
                    new OperacionDTO
                    {
                        IdOperacion = 2,
                        IdAdquiriente = 4,
                        IdVehiculo = 2,
                        CodEstado = EstadoOperacion.EJECUCION,
                        Estado = "En curso",
                        Prestador = "Mario Santos",
                        Adquirente = "Jose Fehler",
                        Vehiculo = "Fiat Palio",
                        MontoAcordado = 500.00m,
                        MontoEfectivo = 550.00m,
                        FechaHoraDesde = DateTime.UtcNow,
                        FechaHoraHasta = DateTime.UtcNow
                    }
                };
                
                prestadorPorEstado.Finalizadas = new List<OperacionDTO>
                {
                    new OperacionDTO
                    {
                        IdOperacion = 6,
                        IdAdquiriente = 3,
                        IdVehiculo = 4,
                        CodEstado = EstadoOperacion.FINALIZADO,
                        Estado = "Finalizado",
                        Prestador = "Mario Santos",
                        Adquirente = "Jose Fehler",
                        Vehiculo = "Fiat Palio",
                        MontoAcordado = 500.00m,
                        MontoEfectivo = 550.00m,
                        FechaHoraDesde = DateTime.UtcNow,
                        FechaHoraHasta = DateTime.UtcNow
                    },
                    new OperacionDTO
                    {
                        IdOperacion = 7,
                        IdAdquiriente = 5,
                        IdVehiculo = 4,
                        CodEstado = EstadoOperacion.CANCELADO,
                        Estado = "Cancelado por Adquiriente",
                        Prestador = "Mario Santos",
                        Adquirente = "Jose Fehler",
                        Vehiculo = "Fiat Palio",
                        MontoAcordado = 500.00m,
                        MontoEfectivo = 550.00m,
                        FechaHoraDesde = DateTime.UtcNow,
                        FechaHoraHasta = DateTime.UtcNow
                    },
                    new OperacionDTO
                    {
                        IdOperacion = 8,
                        IdAdquiriente = 6,
                        IdVehiculo = 4,
                        CodEstado = EstadoOperacion.RECHAZADO,
                        Estado = "Rechazado por Prestador",
                        Prestador = "Mario Santos",
                        Adquirente = "Jose Fehler",
                        Vehiculo = "Fiat Palio",
                        MontoAcordado = 500.00m,
                        MontoEfectivo = 550.00m,
                        FechaHoraDesde = DateTime.UtcNow,
                        FechaHoraHasta = DateTime.UtcNow
                    }
                };

                operaciones.Prestador = prestadorPorEstado;
            }

            return operaciones;
        }
    }
}