import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-linked-data',
  templateUrl: './linked-data.component.html',
  styleUrl: './linked-data.component.scss'
})
export class LinkedDataComponent implements OnInit {
  public head = {
    current: 1,
    next: 2,
    desc: "Node 1"
  };

  public data: any[] = [
    {
      current: 3,
      next: 4,
      desc: "Node 3"
    },
    {
      current: 5,
      next: 6,
      desc: "Node 5"
    },
    {
      current: 2,
      next: 3,
      desc: "Node 2"
    },
    {
      current: 4,
      next: 5,
      desc: "Node 4"
    },
    {
      current: 7,
      next: 8,
      desc: "Node 7"
    }
  ];
  public orphanedData: any[] = [];
  public sortedData: any[] = [];
  public form = this.fb.group({
    current: [null, Validators.required],
    next: [null],
    desc: [null, Validators.required]
  });
  constructor(
    private fb: FormBuilder
  ) {
  }

  ngOnInit(): void {
    this.sort();
  }

  sort() {
    this.orphanedData = [];
    this.sortedData = [];
    const dataCpy: any[] = JSON.parse(JSON.stringify(this.data));
    // prevent infinite loop
    let dataCpyLen = dataCpy.length;
    let head = JSON.parse(JSON.stringify(this.head));
    while(dataCpyLen && dataCpy.length) {
      dataCpyLen--;
      const nextNodeIdx = dataCpy.findIndex(n => parseInt(head.next) ===  parseInt(n.current));
      if (nextNodeIdx >=0) {
        head = dataCpy[nextNodeIdx]
        this.sortedData.push(head);
        dataCpy.splice(nextNodeIdx, 1);
      }
    }

    // the elements still in the list are orphaned
    this.orphanedData = dataCpy;
  }

  addNode() {
    if (this.form.invalid) return;
    console.log(this.form.value)
    this.data.push(this.form.value);
    this.sort();
    this.form.reset();
  }
}
