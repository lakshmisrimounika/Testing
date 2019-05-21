import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailconfigurationComponent } from './emailconfiguration.component';

describe('EmailconfigurationComponent', () => {
  let component: EmailconfigurationComponent;
  let fixture: ComponentFixture<EmailconfigurationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmailconfigurationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailconfigurationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
