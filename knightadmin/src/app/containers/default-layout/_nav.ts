export const navItems = [
  {
    name: "Anasayfa",
    url: "/dashboard",
    icon: "icon-home",
  },
  {
    name: "Oyun İçerikleri",
    url: "/oyun/item",
    icon: "icon-social-dropbox",
    children: [
      {
        name: "İtem",
        url: "/oyun/item",
        icon: "icon-layers"
      },
      {
        name: "Pet",
        url: "/oyun/pet",
        icon: "icon-layers"
      },
      {
        name: "Mob",
        url: "/oyun/mob",
        icon: "icon-layers"
      },
      {
        name: "Merchant",
        url: "/oyun/merchant",
        icon: "icon-layers"
      }
    ]
  },
  {
    name: "Mekan İçerikleri",
    url: "/mekan/area",
    icon: "icon-social-dropbox",
    children: [
      {
        name: "Area",
        url: "/mekan/area",
        icon: "icon-layers"
      },
      {
        name: "Area-Mob",
        url: "/mekan/areamob",
        icon: "icon-layers"
      }
    ]
  },
  {
    name: "Karakter İşlemleri",
    url: "/character/characterlevel",
    icon: "icon-social-dropbox",
    children: [
      {
        name: "Character Level",
        url: "/character/characterlevel",
        icon: "icon-layers"
      },
      {
        name: "Rütbe",
        url: "/character/rutbe",
        icon: "icon-layers"
      }
      
    ]
  },
  {
    name: "WebPage İçerik",
    url: "/icerik/haber",
    icon: "icon-social-dropbox",
    children: [
      {
        name: "Haber",
        url: "/icerik/haber",
        icon: "icon-layers"
      }
      
    ]
  }  
];
