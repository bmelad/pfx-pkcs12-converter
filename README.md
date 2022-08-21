# Convert your PFX / PKCS#12 file to PEM / JKS / PSE easily.
A lot of people doesn't understand the sensitivity of their private keys, and when it comes to handling / conversion of them - it might be dangerous! Online convertion services CANNOT be trusted and no one should upload his private keys to *unknown free conversion services*, because they could save a copy of them during the process.
The solution should be offline conversion using well-known tools, like openssl (for PEM files), keytool (for Java Keystore files) and the proprietary utility for the SAP pse format (sapgenpse), but most of the people are not 'living' the PKI world and might get lost easily when the face it.
For that reason I've created this tiny offline utility which wraps the well-known tools with a simple GUI, so anyone can use it without any worries.

## How to use it?

Just open the app and follow the steps:
 - **Step #1:** Browse for you PFX/P12 source file.
 - **Step #2:** Enter the source PFX's password.
 - **Step #3:** Choose the desired output format (PEM / JKS / PSE).
 - **Step #4:** Enter the destination format's password (Not required for PEM & PSE, but should be at least 6 characters for JKS).
 - **Step #5:** Choose the output file(s) path.

## Notes:
 - When converting to PEM format, there will be two (or three) output files:
 		 - *PEM* file for the certificate.
 		 - *KEY* file for the private key (can be clear-text or encrypted according to your needs).
 		 - (Optional) *CHAIN PEM* file for the issuance chain (if the source file contains it).
- When converting to JKS format - you must enter at least six-characters long destination password.
 - When converting to PSE format, because of this format is proprietary - you'll need to provide the following utility files (the app will popup a open-file-dialog for you to navigate to their path):
		 - sapgenpse.exe
		 - sapcrypto.dll
 - When converting to PSE format - the source PFX file must contain the full issuance chain.

