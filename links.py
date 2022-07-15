text  = """
<link type="text/css" rel="stylesheet"
        href="https://static.xx.fbcdn.net/rsrc.php/v3/yq/l/0,cross/L0VTH1UsUXD.css?_nc_x=Ij3Wp8lg5Kz"
        data-bootloader-hash="0QQt+vI" crossorigin="anonymous" />
    <link type="text/css" rel="stylesheet"
        href="https://static.xx.fbcdn.net/rsrc.php/v3/yK/l/0,cross/fARQz3e8huT.css?_nc_x=Ij3Wp8lg5Kz"
        data-bootloader-hash="Pud6B2Z" crossorigin="anonymous" />
    <link type="text/css" rel="stylesheet"
        href="https://static.xx.fbcdn.net/rsrc.php/v3/yW/l/0,cross/5yI0nhlw4lG.css?_nc_x=Ij3Wp8lg5Kz"
        data-bootloader-hash="145exEj" crossorigin="anonymous" />
    <link type="text/css" rel="stylesheet"
        href="https://static.xx.fbcdn.net/rsrc.php/v3/yH/l/0,cross/LgIyhEMZFoc.css?_nc_x=Ij3Wp8lg5Kz"
        data-bootloader-hash="w/XpzN8" crossorigin="anonymous" />
    <link type="text/css" rel="stylesheet"
        href="https://static.xx.fbcdn.net/rsrc.php/v3/yS/l/0,cross/C3F3YvxPs5P.css?_nc_x=Ij3Wp8lg5Kz"
        data-bootloader-hash="yn3J5CM" crossorigin="anonymous" />
"""
from bs4 import BeautifulSoup
import requests
soup = BeautifulSoup(text, "html.parser")
links = soup.find_all("link")
print(len(links))
for counter, link in enumerate(links, start=1):
    data = requests.get(link["href"]).text
    with open(f"Facebook{counter}.css", "wt") as fp:
        fp.write(data)

