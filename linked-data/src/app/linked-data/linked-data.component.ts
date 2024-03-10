import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-linked-data',
  templateUrl: './linked-data.component.html',
  styleUrl: './linked-data.component.scss'
})
export class LinkedDataComponent implements OnInit {
  constructor() {
  }

  ngOnInit(): void
  {
    console.log("init")
  }

}
