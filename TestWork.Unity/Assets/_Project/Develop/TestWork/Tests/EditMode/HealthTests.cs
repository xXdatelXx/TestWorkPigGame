using System;
using NUnit.Framework;
using TestWork.Gameplay;

namespace TestWork.Tests.EditMode
{
    internal sealed class HealthTests
    {
        [Test]
        public void DieCorrectly()
        {
            var health = new Health(1);

            health.TakeDamage(1);

            Assert.True(health.Died());
        }

        [Test]
        public void CanNotHealByDamage()
        {
            IHealth health = new StrictHealth(new Health(1));
            Assert.Throws<ArgumentOutOfRangeException>(() => health.TakeDamage(-1));
        }

        [Test]
        public void CanNotDamageCorpse()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var health = new Health(1);

                health.TakeDamage(1);
                health.TakeDamage(1);
            });
        }
    }
}