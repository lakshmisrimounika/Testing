import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmailconfigurationeditComponent } from './emailconfigurationedit.component';

describe('EmailconfigurationeditComponent', () => {
  let component: EmailconfigurationeditComponent;
  let fixture: ComponentFixture<EmailconfigurationeditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmailconfigurationeditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmailconfigurationeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
