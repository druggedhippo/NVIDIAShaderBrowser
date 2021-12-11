# NVIDIAShaderBrowser

Displays which processes have shader's cached in the DX NVIDIA shader cache, and their sizes.


Note: NVIDIA drivers lock the shader data whilst it's in use and prevent reading, so running programs may not display immediately

**WARNING**

Using the Clear cache button is not advised, but it's there if you are desperate.

You can also use the NVIDIA drivers to clear the cache properly, put an empty file named *disable.txt* in the shader cache directory.
