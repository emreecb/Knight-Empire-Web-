export const navItems = [
  {
    name: 'Anasayfa',
    url: '/dashboard',
    icon: 'icon-home',
    badge: {
      variant: 'info',
      text: '-'
    }
  },
  {
    divider: true
  },
  {
    title: true,
    name: 'Kurumsal'
  },
  {
    divider: true
  },
  {
    name: 'Hesap Ayarları',
    url: '/hesapbilgileri',
    icon: 'icon-briefcase',
    children: [
      {
        name: 'Hesap Ayarları',
        url: '/hesapbilgileri',
        icon: 'icon-star'
      },
      {
        name: 'Şifre Değiştir',
        url: '/sifredegistir',
        icon: 'icon-star'
      },
      {
        name: 'Bayi',
        url: '/bayi',
        auth: false,
        icon: 'icon-star'
      }/*,
      {
        name: 'Şubelerimiz',
        url: '/kurumsal/subelerimiz',
        icon: 'icon-star'
      },
      {
        name: 'Belgelerimiz',
        url: '/kurumsal/belgelerimiz',
        icon: 'icon-star'
      }*/
    ]
  },
  {
    name: 'Ürün İşlemleri',
    url: '/sepetlerim',
    icon: 'icon-social-dropbox',
    children: [
      /*{
        name: 'Favori Listem',
        url: '/favorilistem',
        icon: 'icon-drawer'
      },*/
      {
        name: 'Sepetlerim',
        url: '/sepetlerim',
        icon: 'icon-drawer'
      }
    ]
  }/*,
  {
    name: 'İnsan Kaynakları',
    url: '/kurumsal/insankaynaklari',
    icon: 'icon-user-following'
  },
  {
    name: 'Sosyal Medya',
    url: '/kurumsal/sosyalmedya',
    icon: 'icon-share'
  },
  {
    name: 'Basın Odası',
    url: '/kurumsal/basinodasi',
    icon: 'icon-globe'
  },
  {
    divider: true
  },
  {
    title: true,
    name: 'WebSite Ayarları'
  },
  {
    divider: true
  },
  {
    name: 'Açılış Bildirim',
    url: '/website/popup',
    icon: 'icon-screen-desktop'
  },
  {
    name: 'Slider',
    url: '/website/slider',
    icon: 'icon-loop'
  },
  {
    name: 'Galeri',
    url: '/website/galeri',
    icon: 'icon-picture'
  },
  {
    name: 'Seo Ayarları',
    url: '/website/seo',
    icon: 'icon-graph'
  },
  {
    name: 'e@mail Yönetim',
    url: '/website/emailyonetim',
    icon: 'icon-envelope-open'
  },
  {
    name: 'Hata Bildir',
    url: '/website/hatabildir',
    icon: 'icon-support',
    badge: {
      variant: 'danger',
      text: 'Hata'
    }
  }*/
];
