using System;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using MonstrosityFramework.API; // Referencia a tu Framework
using MonstrosityFramework.Framework.Data;

namespace MonstrosityDemoPack
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        }

        private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
        {
            // 1. Obtener tu API
            var api = Helper.ModRegistry.GetApi<IMonstrosityApi>("JavCombita.MonstrosityFramework");
            
            if (api == null)
            {
                Monitor.Log("No se pudo cargar la API de Monstrosity.", LogLevel.Error);
                return;
            }

            // 2. Crear datos del monstruo via Código
            var zombieData = new MonsterData
            {
                DisplayName = "Zombie de Código",
                TexturePath = "assets/code_zombie.png",
                // No necesitamos ContentPackID porque somos un mod C# real, 
                // el framework detectará nuestro Manifest automáticamente.
                SpriteWidth = 16,
                SpriteHeight = 24,
                MaxHealth = 50,
                DamageToFarmer = 5,
                BehaviorType = "Default"
            };

            // 3. Registrar
            api.RegisterMonster(this.ModManifest, "CodeZombie", zombieData);
            Monitor.Log("¡Zombie de Código registrado exitosamente!", LogLevel.Info);
        }
    }
}