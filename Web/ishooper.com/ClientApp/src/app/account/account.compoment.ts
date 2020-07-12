import { Component, OnInit } from '@angular/core';
import { User } from './model/user-model';

@Component({
  selector: 'app-account-component',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  user: User = new User();

  ngOnInit(): void {
    //this.mainForm = new FormGroup({
    //  'name': new FormControl(this.hero.name, [
    //    Validators.required,
    //    Validators.minLength(4),
    //    forbiddenNameValidator(/bob/i) // <-- Here's how you pass in the custom validator.
    //  ]),
    //  'alterEgo': new FormControl(this.hero.alterEgo),
    //  'power': new FormControl(this.hero.power, Validators.required)
    //});

  }

  //get firstName() { return this.mainForm.get('firstName'); }

  //get lastName() { return this.mainForm.get('lastName'); }

}