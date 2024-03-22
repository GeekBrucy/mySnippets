import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ILinkedDataObj, data } from '../SampleData';

@Component({
  selector: 'app-linked-data-obj',
  templateUrl: './linked-data-obj.component.html',
  styleUrl: './linked-data-obj.component.scss'
})
export class LinkedDataObjComponent implements OnInit {

  public orphanedData: any[] = [];
  public sortedData: any[] = [];
  public form = this.fb.group({
    isNew: [true],
    id: [null],
    current: [null, Validators.required],
    next: [null],
    desc: [null, Validators.required]
  });

  head: ILinkedDataObj | null = null;

  constructor(
    private fb: FormBuilder
  ) {
  }

  ngOnInit(): void {

  }

  get id(): any {
    return this.form.get("id")?.value;
  }

  sort() {
    const dataCpy: ILinkedDataObj[] = JSON.parse(JSON.stringify(data));
    let dataLen = dataCpy.length;
    const headIdx = dataCpy.findIndex(d => !!d.previous);
    this.head = dataCpy[headIdx];
    dataCpy.splice(headIdx, 1);
    this.sortedData.push(this.head);
    while(dataCpy.length && dataLen) {
      dataLen--;
      // const nextId =
      const node = dataCpy.findIndex(d => this.head?.next)
    }
  }

  edit(node: any) {

  }

  create(node: any) {

  }

  addNode() {

  }
}
