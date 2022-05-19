using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType; //validtörler type ile tanımlanır.
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil!");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //çalışma tipini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //parametreleri bul
            foreach (var entity in entities)
            {

                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
