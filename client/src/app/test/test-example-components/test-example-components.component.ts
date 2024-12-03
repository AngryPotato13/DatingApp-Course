import { Component, TemplateRef } from '@angular/core';
import { CarouselConfig, CarouselModule } from 'ngx-bootstrap/carousel';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
 import { TypeaheadModule } from 'ngx-bootstrap/typeahead';

@Component({
  selector: 'app-test-example-components',
  standalone: true,
  imports: [CarouselModule, AccordionModule,BsDropdownModule, TabsModule, ModalModule, TooltipModule, TypeaheadModule],     
  templateUrl: './test-example-components.component.html',
  styleUrl: './test-example-components.component.css',
  providers: [
    { provide: CarouselConfig, useValue: { interval: 3000, noPause: true, showIndicators: false } }    //This is for carousel
  ]
})
export class TestExampleComponentsComponent {
  selected?: string;
  names: string[] = ['Kieran', 'Jorja', 'Vex', 'FN-T3DDY', 'fligbert', 'flogbert', 'grim', 'fluffy-tuffy', 'big-white-teddy', 'kitty'];



  modalRef?: BsModalRef;                                             //This is for modal
  TabOpen?: any;
  config ={backdrop: true, ignoreBackdropClick: true};               //This is for modal

  constructor(private modalService: BsModalService){}                //This is for modal


  openModal(template: TemplateRef<void>){                            //This is for modal
    this.modalRef = this.modalService.show(template,this.config);
  }
}
