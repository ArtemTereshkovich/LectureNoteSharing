import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {

  modalRef: BsModalRef;
  items: any[];

  public markdownText: string;

  constructor(private modalService: BsModalService) {
    this.items = Array(15).fill(0);
  }

  ngOnInit() {
    this.markdownText = '# Header ## another';
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

}
