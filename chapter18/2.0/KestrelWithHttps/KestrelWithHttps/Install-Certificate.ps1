# Run this script to create a test certificate in the local directory, and trust it

# Create the certificate
$cert = New-SelfSignedCertificate -Subject localhost -DnsName localhost -FriendlyName "ASP.NET Core Development" -KeyUsage DigitalSignature -TextExtension @("2.5.29.37={text}1.3.6.1.5.5.7.3.1")
$mypwd = ConvertTo-SecureString -String "testpassword" -Force -AsPlainText
Export-PfxCertificate -Cert $cert -FilePath .\localhost.pfx -Password $mypwd

# Trust the certificate
Import-PfxCertificate -FilePath .\localhost.pfx -Password $mypwd -CertStoreLocation cert:/CurrentUser/Root