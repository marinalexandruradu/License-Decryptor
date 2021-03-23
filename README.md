# License-Decryptor

This is a project meant as an example on how you can generate license keys for your product, and how to implement the check in your MSI package. The License Generator can be found [in my other repository](https://github.com/marinalexandruradu/License-Generator/blob/main/README.md).

Once we have the keys generated, we implement this .DLL file in a Custom Action in the MSI. 

![image](https://user-images.githubusercontent.com/13455334/112224759-6ffd6e80-8c34-11eb-93e6-461ef8b6dd4c.png)


We also need to pass the license via a "Set Property"

![image](https://user-images.githubusercontent.com/13455334/112224772-74c22280-8c34-11eb-81e7-2c565ed51279.png)

If the license key is correct, the product will be installed. If not, a message will appear to the user and the installation will be canceled.


![image](https://user-images.githubusercontent.com/13455334/112224832-8e636a00-8c34-11eb-98bf-eaac0b044af5.png)

Disclaimer: This project is only meant for teaching purposes, this is not the most secure way to handle licenses in your installer. Idealy this must be handled from the application itself, not the MSI. Use at your own risk, I will not be held responsible for any "breaches" in your installers.
