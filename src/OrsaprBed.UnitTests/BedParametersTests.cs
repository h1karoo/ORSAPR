﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ModelParameters;

namespace OrsaprBed.UnitTests
{
    [TestFixture]
    public class NightstandParametersTests
    {
        /// <summary>
        /// Словарь для хранения сведения о параметров кровать
        /// </summary>
        private Dictionary<string, Parameter> TestingParameter
        {
            get
            {
                var bed = new BedParameters { };
                return new Dictionary<string, Parameter>
                {
                    {nameof(bed.Length), bed.Length},
                    {nameof(bed.Height), bed.Height},
                    {nameof(bed.Width), bed.Width},
                    {nameof(bed.Thickness), bed.Thickness},
                    {nameof(bed.Distance), bed.Distance},
                };
            }
        }

        /// <summary>
        /// Лист с назаванием параметров
        /// </summary>
        /// <param name="nightstand">Экземпляр класса NightstandParameters</param>
        /// <returns></returns>
        private List<Parameter> InitializeParameters(BedParameters bed)
        {
            var parameters = new List<Parameter>
            {
                bed.Length,
                bed.Height,
                bed.Width,
                bed.Thickness,
                bed.Distance,
        };
            return parameters;
        }

        [TestCase("Width", TestName = "Позитивный метод для BodyDiameter, производится ввод и " +
                                             "считывание параметров")]
        [TestCase("Height", TestName = "Позитивный метод для BodyHeight, производится ввод и " +
                                          "считывание параметров")]
        [TestCase("Length", TestName = "Позитивный метод для SocketPlatformDiameter," +
                                                       " производится ввод и считывание параметров")]
        [TestCase("Thickness", TestName = "Позитивный метод для SocketPlatformDiameter," +
                                                       " производится ввод и считывание параметров")]

        [TestCase("Distance", TestName = "Позитивный метод для TubeDiameter, производится ввод и" +
                                             " считывание параметров")]
        public void Test_GoodParameter_ReternSameParameter(string nameParameter)
        {
            // Setup
            Parameter myParameter;
            if (TestingParameter.TryGetValue(nameParameter, out myParameter))
            {
                Parameter sourceParameter = new Parameter(
                    "Testing Parameter",
                    1800,
                    2000,
                    1900);
                var expectedParameter = sourceParameter;

                // Act
                myParameter = sourceParameter;
                var actualParameter = myParameter;

                //Assert
                NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
            }
            else
            {
                throw new ArgumentException("Name parameter not found");
            }
        }

        [TestCase(TestName = "Позитивный метод для MaxValue, производится ввод и считывание " +
                             "параметров")]
        public void MaxValue_GoodNightstandParameters_MaximumValueEqualValue()
        {
            // Setup
            var nightstand = new BedParameters();
            var parameters = InitializeParameters(nightstand);
            nightstand.MaxValue();
            foreach (var currentParameter in parameters)
            {

                var expectedValue = currentParameter.MaximumValue;

                // Act
                var actualValue = currentParameter.Value;

                // Assert
                NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestCase(TestName = "Позитивный метод для MinValue, производится ввод и считывание " +
                             "параметров")]
        public void MinValue_GoodNightstandParameters_MinimumValueEqualValue()
        {
            // Setup
            var nightstand = new BedParameters();
            var parameters = InitializeParameters(nightstand);
            nightstand.MinValue();
            foreach (var currentParameter in parameters)
            {

                var expectedValue = currentParameter.MinimumValue;

                // Act
                var actualValue = currentParameter.Value;

                // Assert
                NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestCase(TestName = "Позитивный метод для DefaultValue, производится ввод и " +
                             "считывание параметров")]
        public void DefaultValue_GoodNightstandParameters_DefaultValueEqualValue()
        {
            // Setup
            var nightstand = new BedParameters();
            var parameters = InitializeParameters(nightstand);
            nightstand.DefaultValue();
            foreach (var currentParameter in parameters)
            {

                var expectedValue = currentParameter.DefaultValue;

                // Act
                var actualValue = currentParameter.Value;

                // Assert
                NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
            }
        }

    }
}