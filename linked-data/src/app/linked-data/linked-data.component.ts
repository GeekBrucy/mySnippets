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
    desc: "Start Transition"
  };

  public data: any[] = [
    {
      isNew: false,
      id: 3,
      current: 3,
      next: 4,
      desc: "Transition 3"
    },
    {
      isNew: false,
      id: 5,
      current: 5,
      next: 6,
      desc: "Transition 5"
    },
    {
      isNew: false,
      id: 2,
      current: 2,
      next: 3,
      desc: "Transition 2"
    },
    {
      isNew: false,
      id: 4,
      current: 4,
      next: 5,
      desc: "Transition 4"
    },
    {
      isNew: false,
      id: 7,
      current: 7,
      next: 8,
      desc: "Transition 7"
    }
  ];
  public orphanedData: any[] = [];
  public sortedData: any[] = [];
  public form = this.fb.group({
    isNew: [true],
    id: [null],
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

  get id(): any {
    return this.form.get("id")?.value;
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

    if (head.next) {
      this.sortedData.push({
        isNew: true,
        id: null,
        current: head.next,
        next: null,
        desc: "Unknown Node"
      });
    }

    // the elements still in the list are orphaned
    this.orphanedData = dataCpy;
  }

  addNode() {
    if (this.form.invalid) return;

    const formVal = this.form.value;
    let existingNode = this.data.findIndex(node => parseInt(node.id) === parseInt(formVal.id!));

    // avoid duplicate node
    if (existingNode >=0) {
      this.data.splice(existingNode, 1, formVal)
    } else {
      this.data.push(formVal);
    }

    this.sort();
    this.form.reset();
  }

  edit(node: any): void {
    this.form.reset();
    this.form.patchValue(node);
  }

  create(node: any): void {
    this.form.reset();
    this.form.patchValue({current: node.current});
  }
}
