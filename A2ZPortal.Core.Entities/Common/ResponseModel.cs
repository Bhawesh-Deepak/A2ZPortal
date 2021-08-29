using System.Collections.Generic;

namespace A2ZPortal.Core.Entities.Common
{
    public record ResponseModel<TEntity>
    {
        public TEntity Entity { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
        public string Message { get; set; }

        public ResponseModel(TEntity entity, IEnumerable<TEntity> tEntities, ResponseStatus responseStatus,
            string message)
        {
            Entities = tEntities;
            Entity = entity;
            ResponseStatus = responseStatus;
            Message = message;
        }

        public ResponseModel()
        {
        }
    }
}