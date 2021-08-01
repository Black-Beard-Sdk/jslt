namespace Bb.Extensions.Secures
{
    public class VaultEntry
    {

        public string Key { get; set; }

        public string Value { get; set; }

        internal string Decode(Vault vault)
        {
            return vault.SecureProcessor().Decrypt(Value);
        }

        internal void Store(Vault vault, string value)
        {
            Value = vault.SecureProcessor().Encrypt(value);
        }
    }

}
