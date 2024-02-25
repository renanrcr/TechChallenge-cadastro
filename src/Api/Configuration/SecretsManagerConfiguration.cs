namespace TechChallenge.Api.Configuration
{
    public static class SecretsManagerConfiguration
    {
        public static void AddAmazonSecretsManager(this IConfigurationBuilder configurationBuilder,
                                string region,
                                string secretName)
        {
            var configurationSource =
                    new AmazonSecretsManagerConfigurationSource(region, secretName);

            configurationBuilder.Add(configurationSource);
        }
    }
}