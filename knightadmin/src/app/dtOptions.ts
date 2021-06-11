export const dtOptions = {
  info: true,
  pageLength: 50,
  columnDefs: [ {
    "targets": [0,1,2,3,4],
    "orderable": false
    } ],
  'language': {
    'lengthMenu': 'Sayfada _MENU_ öğe görüntüle',
    'zeroRecords': 'Veri Alınamadı - Lütfen Sayfayı Yenileyin',
    'info': 'Gösterilen Sayfa _PAGE_ - _PAGES_ ',
    'infoEmpty': 'Kayıt yok',
    'search': 'Ara:',
    'infoFiltered': '(Toplam _MAX_ kayıt arasından filtrelendi)',
    'loadingRecords': 'Loading...',
    'processing': 'Processing...',
    'paginate': {
      'first': 'ilk',
      'last': 'Son',
      'next': 'sonraki',
      'previous': 'önceki'
    },
    'aria': {
      'sortAscending': ': Baştan sona sırala',
      'sortDescending': ': Sondan Başa Sırala'
    },
    'thousands': '.'
  },
  dom: 'Bfrtip',
  buttons: [
    {
      extend: 'copy',
      text: 'Kopyala'
    },
    {
      extend: 'print',
      text: 'Yazdır'
    },
    {
      extend: 'excel',
      text: 'Excel Çıktısı'
    },
    {
      extend: 'pageLength',
      text: 'Göster',
    },
  ]
};
