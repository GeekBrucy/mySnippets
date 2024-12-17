- Process highly sensitive data in an isolated compute environment
  - Personally Identifiable Information (PII), healthcare, financial,...
- Fully isolated virtual machines, hardened, and highly constrained
  - Not a container, not persistent storage, no interactive access, no external networking
- Helps reduce the attack surface for sensitive data processing apps
  - Cryptographic Attestation - only authorized code can be running in your Enclave
  - Only Enclaves can access sensitive data (integration with KMS)
- Use cases: securing private keys, processing credit cards, secure multi-party computation...

# How it works

1. Launch a compatible Nitro-based EC2 instance with the "EnclaveOptions" parameter set to "true"
2. Use the Nitro CLI to convert your app to an Enclave Image File (EIF)
3. Using the EIF file as an input, use the Nitro CLI to create an Enclave
4. The Enclave is a separate virtual machine with its own kernel, memory, and CPU
