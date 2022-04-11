# Subdomained-Mtls-Lab

This is a web-application to lab with mTLS. The main-domain wihout mTLS and a subdomain with mTLS.

To be able to run in Visual Studio on Windows you need to add the following to **C:\Windows\System32\drivers\etc\hosts**:

	127.0.0.1 example.local
	127.0.0.1 mtls.example.local

## 1 TLS-certificates

There are three TLS-certificates for the application. To be able to do a full test, you need to put the certificates in your Root CA trust (LocalMachine/Root). To be able to find them easy later, to be able to remove them from the Root CA trust, they are named "CN=____DELETE_THIS_CA_AFTER_TESTING *".

If you do not trust the certificates all environments will work. But if you trust the certificates only the following environments will work:

- Port-Multiple-Certificates
- Port-One-Certificate
- Sni-Multiple-Certificates

### 1.1 example.local

- Certificate-pem: example.local.crt
- Certificate-key: example.local.key
- Subject: CN=____DELETE_THIS_CA_AFTER_TESTING - example.local

### 1.2 mtls.example.local

- Certificate-pem: mtls.example.local.crt
- Certificate-key: mtls.example.local.key
- Subject: CN=____DELETE_THIS_CA_AFTER_TESTING - mtls.example.local

### 1.3 mtls.example.local

- Certificate-pem: example.local-and-mtls.example.local.crt
- Certificate-key: example.local-and-mtls.example.local.key
- Subject: CN=____DELETE_THIS_CA_AFTER_TESTING - example.local and mtls.example.local