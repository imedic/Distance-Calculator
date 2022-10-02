import { FormGroup } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';

@Component({
    selector: 'app-calculator-form',
    styleUrls: ['calculator-form.component.css'],
    templateUrl: 'calculator-form.component.html'
})

export class CalculatorFormComponent implements OnInit {
    @Input() form!: FormGroup;

    constructor() { }

    ngOnInit() { }
}