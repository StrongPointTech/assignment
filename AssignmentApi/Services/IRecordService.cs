using System.Reflection.Metadata.Ecma335;
using AssignmentApi.Data;
using AssignmentLibrary.Enums;
using AssignmentLibrary.ViewModels;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace AssignmentApi.Services
{
    public interface IRecordService
    {
        IEnumerable<RecordViewModel> GetAllRecords(MassUnit massUnit, VelocityUnit velocityUnit, EnergyUnit energyUnit);
        void CreateRecord(RecordViewModel model);
    }

    public class RecordService : IRecordService
    {
        private readonly AssignmentDb assignmentDb;
        public RecordService(AssignmentDb db)
        {
            assignmentDb = db;
        }

        public IEnumerable<RecordViewModel> GetAllRecords(MassUnit massUnit, VelocityUnit velocityUnit, EnergyUnit energyUnit)
        {
            return assignmentDb.Records.Select(r => new RecordViewModel
            {
                Velocity = VelocityFromSiSystemUnits(r.Velocity, velocityUnit),
                Mass = MassFromSiSystemUnits(r.Mass, massUnit),
                Energy = EnergyFromSiSystemUnits(r.Energy, energyUnit),
                ImpactResult = r.ImpactResult,
            }).AsEnumerable();

        }

        public void CreateRecord(RecordViewModel model)
        {
            var entity = new Record
            {
                Mass = MassToSiSystemUnits(model.Mass, model.MassUnit),
                Velocity = VelocityToSiSystemUnits(model.Velocity, model.VelocityUnit)
            };
            entity.Energy = CalculateEnergy(entity.Mass, entity.Velocity);
            entity.ImpactResult = "Boom";

            assignmentDb.Records.Add(entity);
            assignmentDb.SaveChanges();
        }

        private decimal CalculateEnergy(decimal mass, decimal velocity)
        {
            var calculation =  mass * velocity / 2;

            return Math.Round(calculation);
        }

        private static decimal MassToSiSystemUnits(decimal mass, MassUnit unit)
        {
            var calculation = unit switch
            {
                MassUnit.kg => mass,
                MassUnit.g => mass / 1000,
                MassUnit.lb => mass * (decimal) 0.454,
                MassUnit.oz => mass * (decimal) 0.02835,
                MassUnit.t => mass * 1000
            };

            return Math.Round(calculation);
        }

        private static decimal VelocityToSiSystemUnits(decimal velocity, VelocityUnit unit)
        {
            var calculation = unit switch
            {
                VelocityUnit.MetersPerSecond => velocity,
                VelocityUnit.FootsPerSecond => velocity * (decimal) 0.3048,
                VelocityUnit.KilometersPerHour => velocity * (decimal) 1000 / 3600,
                VelocityUnit.MilesPerHour => velocity * (decimal) 1609 / 3600
            };

            return Math.Round(calculation,2);
        }

        private static decimal EnergyFromSiSystemUnits(decimal energy, EnergyUnit unit)
        {
            var calculation = unit switch
            {
                EnergyUnit.BTU => energy / (decimal)1055.05585262,
                EnergyUnit.J => energy,
                EnergyUnit.MJ => energy * 1000000,
                EnergyUnit.cal => energy / (decimal)4.184
            };
            return Math.Round(calculation,2);
        }

        private static decimal VelocityFromSiSystemUnits(decimal velocity, VelocityUnit unit)
        {
            var calculation = unit switch
            {
                VelocityUnit.MetersPerSecond => velocity,
                VelocityUnit.FootsPerSecond => velocity / (decimal)0.3048,
                VelocityUnit.KilometersPerHour => velocity / (decimal)1000 * 3600,
                VelocityUnit.MilesPerHour => velocity /(decimal)1609 * 3600
            };

            return Math.Round(calculation,2);
        }

        private static decimal MassFromSiSystemUnits(decimal mass, MassUnit unit)
        {
            var calculation = unit switch
            {
                MassUnit.kg => mass,
                MassUnit.g => mass * 1000,
                MassUnit.lb => mass / (decimal)0.454,
                MassUnit.oz => mass / (decimal)0.02835,
                MassUnit.t => mass / 1000
            };

            return Math.Round(calculation, 2);
        }

    }
}
