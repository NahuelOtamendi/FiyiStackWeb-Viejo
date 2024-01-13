using DocumentFormat.OpenXml.EMMA;

namespace FiyiStackWeb.PayPalConfiguration
{
    public class PayPalConfiguration
    {
        public string Mode = "live";
        public string Paypal_URL = "https://api-m.paypal.com";
        public string ClientID = "AbMkhyMmOtCjQSB41kdJi_L4oeahwf-AGrA2WxtUTFFOucyvyzC9w3VDv1G8unMHQbo252Qn6dEnacOP";
        public string ClientSecret = "EPe_6MZnnfGhA22pkXJ-YfHdiSM_SXdqtkBz_JkMwXnSaYXgaePoHlLe6yaduCrwqUpAbb2SWyLjTi14";
        public string PlanProID = "P-4DW16813VL5440120MTK35QY";
        public string PlanAmateurID = "P-6MG59534PM2142008MTK35DY";
        public PayPalConfiguration() {
            if (Mode == "sandbox")
            {
                ClientID = "AWI37KYzQGZVqijEFYEVQoBt12lKR1j11cyBjgfA2YIym242o9WkCZ7WNi5FL7A6d1EMyVsIr4R03dyk";

                ClientSecret = "EEijE-eubNd423impahC7pIBha1cWuP1b4LPFdJgGo4TW6vCrPKXEVipb7abvc8tND0HTKqyPalhYW4Y";

                Paypal_URL = "https://api-m.sandbox.paypal.com";
                PlanProID = "P-1524357668769193UMTHV42Q";
                PlanAmateurID = "P-34666703UL7982730MTHV4DA";
            }
        }
        
    }
}
