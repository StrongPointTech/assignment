using AssignmentApi.Data;
using AssignmentLibrary.Enums;
using AssignmentLibrary.ViewModels;
using AssignmentApi.Helpers;

namespace AssignmentApi.Services
{
    public interface IRecordService
    {
        IEnumerable<RecordViewModel> GetAllRecords(MassUnit massUnit, VelocityUnit velocityUnit, EnergyUnit energyUnit);
        RecordViewModel CreateRecord(RecordViewModel model);
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
                Velocity = CalculationHelper.VelocityFromSiSystemUnits(r.Velocity, velocityUnit),
                Mass = CalculationHelper.MassFromSiSystemUnits(r.Mass, massUnit),
                Energy = CalculationHelper.EnergyFromSiSystemUnits(r.Energy, energyUnit),
                ImpactResult = r.ImpactResult,
            }).AsEnumerable();

        }

        public RecordViewModel CreateRecord(RecordViewModel model)
        {
            var entity = new Record
            {
                Mass = CalculationHelper.MassToSiSystemUnits(model.Mass.Value, model.MassUnit),
                Velocity = CalculationHelper.VelocityToSiSystemUnits(model.Velocity.Value, model.VelocityUnit)
            };
            entity.Energy = CalculationHelper.CalculateEnergy(entity.Mass, entity.Velocity);
            entity.ImpactResult = CalculationHelper.ImpactResult(entity.Energy);

            assignmentDb.Records.Add(entity);
            assignmentDb.SaveChanges();

            model.EnergeUnit = EnergyUnit.J;
            model.Energy = entity.Energy;
            model.ImpactResult = entity.ImpactResult;

            return model;
        }

       

    }
}
