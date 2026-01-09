using System;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace JacketPassiveEnhancement
{
    [BepInPlugin("jacket.passive", "Jacket Passive Enhancement", "1.0.0")]
    public class JacketPassiveEnhancement : BaseUnityPlugin
    {
        void Awake()
        {
            Logger.LogInfo("✅ MOD CARREGADO - Investigando API...");
            StartCoroutine(InvestigateAPI());
        }
        
        private System.Collections.IEnumerator InvestigateAPI()
        {
            yield return new WaitForSeconds(2f);
            
            try
            {
                // Tenta encontrar PlayerController
                var players = UnityEngine.Object.FindObjectsOfType<UnityEngine.Object>();
                foreach (var obj in players)
                {
                    if (obj.GetType().Name == "PlayerController")
                    {
                        Logger.LogInfo($"📝 Encontrado: {obj.GetType().FullName}");
                        
                        // Lista propriedades públicas
                        var properties = obj.GetType().GetProperties();
                        foreach (var prop in properties)
                        {
                            if (prop.Name.ToLower().Contains("gun") || prop.Name.ToLower().Contains("start"))
                            {
                                Logger.LogInfo($"   🔍 Propriedade: {prop.Name} (Tipo: {prop.PropertyType.Name})");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError($"Erro na investigação: {e.Message}");
            }
        }
    }
}