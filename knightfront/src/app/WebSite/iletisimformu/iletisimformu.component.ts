import { Component, OnInit } from '@angular/core';
import { GlobalService } from 'src/app/_Services/global.service';
import { ToastrService } from 'src/app/_Services/toastr.service';

@Component({
  selector: 'app-iletisimformu',
  templateUrl: './iletisimformu.component.html',
  styleUrls: ['./iletisimformu.component.scss']
})
export class IletisimformuComponent implements OnInit {
  selectedFile: File = null;
  private url = '/IletisimFormu';
  iletisimobje: any = {
    id: 0,
    adSoyad: '',
    email: '',
    telefon: '',
    konu: '',
    mesaj: '',
    sonuclanma: false,
    okunmaDurumu: false,
    eklenmeTarihi: null,
    dosya: null
  };


  constructor(public service: GlobalService, private toastService: ToastrService) { }


  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
  }

  onUpload(id) {
    console.log('on');

    const fd = new FormData();
    if (this.selectedFile != null) {
      console.log('on-resp');

      fd.append('atilganfile', this.selectedFile, this.selectedFile.name);
      this.service.Patch(this.url, id, fd).subscribe((resp) => {
        this.toastService.Success();
        this.clearObj();
      });
    } else {
      this.toastService.Success();
      this.clearObj();
    }
  }
  clearObj() {
    this.iletisimobje = {
      id: 0,
      adSoyad: '',
      email: '',
      telefon: '',
      konu: '',
      mesaj: '',
      sonuclanma: false,
      okunmaDurumu: false,
      eklenmeTarihi: null,
      dosya: null
    };
  }
  update() {
    this.service.Update(this.url, this.iletisimobje).subscribe(
      (resp: any) => {
        if (this.selectedFile != null) {
          this.onUpload(resp.id);
        } else {
          this.toastService.Success();
          this.clearObj();
        }

      });
  }

  ngOnInit() {
  }

}
