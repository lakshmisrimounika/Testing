import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AlumniLoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: AlumniLoginComponent;
  let fixture: ComponentFixture<AlumniLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AlumniLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AlumniLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
